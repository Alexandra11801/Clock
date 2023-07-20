using Clock.AlarmManagement;
using UnityEngine;

namespace Clock.UI
{
    public class SaveAlarmButton : OpenSceneButton
    {
        [SerializeField] private AlarmSetupManager alarmSetupManager;
        
        public override void OnClick()
        {
            alarmSetupManager.SaveAlarm();
            base.OnClick();
        }
    }
}