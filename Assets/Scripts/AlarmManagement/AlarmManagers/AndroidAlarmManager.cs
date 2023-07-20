using System;
using Unity.Notifications.Android;

namespace Clock.AlarmManagement
{
    public class AndroidAlarmManager : AlarmManager
    {
        private const string ANDROID_NOTIFICATION_CHANNEL_ID = "alarm_channel";
        private int androidNotificationId;
        
        public override void Initialize()
        {
            var androidNotificationChannel = new AndroidNotificationChannel()
            {
                Id = ANDROID_NOTIFICATION_CHANNEL_ID,
                Name = "Alarm Channel",
                Description = "Alarm notifications",
                Importance = Importance.High,
                EnableVibration = true
            };
            AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChannel);
            AndroidNotificationCenter.OnNotificationReceived += NotificationReceived;
            androidNotificationId = -1;
        }

        public override void SetAlarm(DateTime time)
        {
            base.SetAlarm(time);
            if (androidNotificationId != -1)
            {
                AndroidNotificationCenter.CancelNotification(androidNotificationId);
            }
            var timeString = alarmTime.ToString("HH:mm:ss");
            var alarmNotification = new AndroidNotification()
            {
                Title = "Alarm",
                Text = String.Format("It's {0}!", timeString),
                FireTime = systemAlarmTime,
                IntentData = timeString
            };
            androidNotificationId = AndroidNotificationCenter.SendNotification(alarmNotification, 
                ANDROID_NOTIFICATION_CHANNEL_ID);
        }

        private void NotificationReceived(AndroidNotificationIntentData intentData)
        {
            if (intentData.Id == androidNotificationId)
            {
                androidNotificationId = -1;
                alarmTime = default;
            }
        }
    }
}