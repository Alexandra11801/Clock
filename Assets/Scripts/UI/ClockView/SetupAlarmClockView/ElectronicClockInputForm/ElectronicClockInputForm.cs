using System;
using UnityEngine;

namespace Clock.UI.ClockView.SetupAlarm
{
    public class ElectronicClockInputForm : MonoBehaviour
    {
        [SerializeField] private SetupAlarmClockView clockView;
        [SerializeField] private ElectronicClockInputField hours;
        [SerializeField] private ElectronicClockInputField minutes;
        [SerializeField] private ElectronicClockInputField seconds;

        private void Awake()
        {
            hours.SetClampValues(0, 23);
            minutes.SetClampValues(0, 59);
            seconds.SetClampValues(0, 59);
        }

        public void UpdateTime()
        {
            clockView.SetTime(GetTime());
        }
        
        public void SetTime(TimeSpan time)
        {
            hours.InputField.text = time.Hours.ToString("00");
            minutes.InputField.text = time.Minutes.ToString("00");
            seconds.InputField.text = time.Seconds.ToString("00");
        }

        public TimeSpan GetTime()
        {
            return new TimeSpan(
                Int32.Parse(hours.InputField.text),
                Int32.Parse(minutes.InputField.text),
                Int32.Parse(seconds.InputField.text));
        }
    }
}