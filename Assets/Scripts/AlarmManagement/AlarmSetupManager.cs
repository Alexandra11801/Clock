using System;
using Clock.ApplicationManagement;
using Clock.ClockManagement;
using Clock.UI.ClockView.SetupAlarm;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Clock.AlarmManagement
{
    public class AlarmSetupManager : MonoBehaviour
    {
        [SerializeField] private SetupAlarmClockView view;
        private TimeSpan setUpTime;

        public TimeSpan SetUpTime
        {
            get => setUpTime;
            set => setUpTime = value;
        }

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += SetupView;
        }
        
        private void OnDisable()
        {
            SceneManager.activeSceneChanged -= SetupView;
        }
        
        private void SetupView(Scene arg0, Scene mode)
        {
            view.SetTime(ApplicationManager.Instance.AlarmManager.AlarmTime == default ? ClockManager.Instance.Time.TimeOfDay 
                : ApplicationManager.Instance.AlarmManager.AlarmTime.TimeOfDay);
        }

        public void SaveAlarm()
        {
            var currentDateTime = ClockManager.Instance.Time;
            var setUpDateTime = currentDateTime.Date.Add(setUpTime);
            if (setUpTime <= currentDateTime.TimeOfDay)
            {
                setUpDateTime = setUpDateTime.AddDays(1);
            }
            ApplicationManager.Instance.AlarmManager.SetAlarm(setUpDateTime);
        }
    }
}