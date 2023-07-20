using System;
using Clock.AlarmManagement;
using UnityEngine;

namespace Clock.UI.ClockView.SetupAlarm
{
    public class SetupAlarmClockView : ClockView
    {
        [SerializeField] private AlarmSetupManager alarmSetupManager;
        [SerializeField] private ElectronicClockInputForm inputForm;

        public AlarmSetupManager AlarmSetupManager => alarmSetupManager;

        public override void SetTime(TimeSpan time)
        {
            base.SetTime(time);
            alarmSetupManager.SetUpTime = time;
        }

        protected override void SetElectronicClockValue(TimeSpan time)
        {
            inputForm.SetTime(time);
        }
    }
}