using System;
using System.Collections;
using Clock.WebClient;
using Clock.UI.ClockView;
using Clock.UI.ClockView.SetupAlarm;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Clock.ClockManagement
{
    public class ClockManager : MonoBehaviour
    {
        [SerializeField] private int secondsBetweenValidation;
        private static ClockManager instance;
        private ClockView view;
        private DateTime time;
        private DateTime lastValidationTime;

        public static ClockManager Instance => instance;
        public DateTime Time => time;

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            time = DateTime.Now;
            SceneManager.activeSceneChanged += TrySetupView;
            StartCoroutine(nameof(ValidateTimeRoutine));
            StartCoroutine(nameof(UpdateTimeRoutine));
        }

        private IEnumerator UpdateTimeRoutine()
        {
            while (true)
            {
                if (view != null)
                {
                    view.SetTime(time.TimeOfDay);
                }
                yield return new WaitForSeconds(1);
                time = time.AddSeconds(1);
            }
        }

        private IEnumerator ValidateTimeRoutine()
        {
            while (true)
            {
                var validTime1 = NistClient.GetNISTTime();
                var validTime2 = NTPClient.GetGoogleTimeTime();
                DateTime validTime;
                if (validTime1 != validTime2)
                {
                    var averageTicks = (validTime1.Ticks + validTime2.Ticks) / 2;
                    validTime = new DateTime(averageTicks);
                }
                else
                {
                    validTime = validTime1;
                }
                if (time == default || time != validTime2)
                {
                    time = validTime2;
                }
                lastValidationTime = time;
                yield return new WaitUntil(() => time.Subtract(lastValidationTime).Seconds >= secondsBetweenValidation);
            }
        }

        public void AddTime(TimeSpan time)
        {
            this.time += time;
        }

        private void TrySetupView(Scene arg0, Scene mode)
        {
            var view = FindObjectOfType<MainClockView>();
            if (view != null)
            {
                this.view = view;
                view.SetTime(time.TimeOfDay);
            }
        }
    }
}