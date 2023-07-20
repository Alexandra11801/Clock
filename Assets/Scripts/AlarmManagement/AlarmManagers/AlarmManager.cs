using System;
using Clock.ClockManagement;

namespace Clock.AlarmManagement
{
    public class AlarmManager
    {
        protected DateTime alarmTime;
        protected DateTime systemAlarmTime;

        public DateTime AlarmTime => alarmTime;

        public virtual void Initialize(){}

        public virtual void SetAlarm(DateTime time)
        {
            alarmTime = time;
            systemAlarmTime = time.Add(ClockManager.Instance.Time - DateTime.Now);
        }
    }
}