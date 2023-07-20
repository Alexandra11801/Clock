using System;
using Clock.AlarmManagement;
using Clock.ClockManagement;
using UnityEngine;

namespace Clock.ApplicationManagement
{
    public class ApplicationManager : MonoBehaviour
    {
        private static ApplicationManager instance;
        private AlarmManager alarmManager;
        private DateTime systemPauseTime;
        private bool wasPaused;

        public static ApplicationManager Instance => instance;
        public AlarmManager AlarmManager => alarmManager;

        private void Start()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);
            
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    alarmManager = new AndroidAlarmManager();
                    break;
                default:
                    alarmManager = new AlarmManager();
                    break;
            }
            alarmManager.Initialize();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                systemPauseTime = DateTime.Now;
                wasPaused = true;
            }
            else if(wasPaused)
            {
                wasPaused = false;
                var timeSpentOnPause = DateTime.Now.Subtract(systemPauseTime);
                ClockManager.Instance.AddTime(timeSpentOnPause);
            }
        }
    }
}