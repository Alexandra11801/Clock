using System;

namespace Clock.Utils
{
    public static class TimeConvertingUtils
    {
        public struct HandsConfiguration
        {
            public float hourHandRotation;
            public float minuteHandRotation;
            public float secondHandRotation;

            public HandsConfiguration(float hourHandRotation, float minuteHandRotation, float secondHandRotation)
            {
                this.hourHandRotation = hourHandRotation;
                this.minuteHandRotation = minuteHandRotation;
                this.secondHandRotation = secondHandRotation;
            }
        }

        public static HandsConfiguration TimeToHandsConfiguration(TimeSpan time)
        {
            var handsConfiguration = new HandsConfiguration(0, 0, 0);
            handsConfiguration.secondHandRotation = time.Seconds * 6;
            handsConfiguration.minuteHandRotation = (time.Minutes + handsConfiguration.secondHandRotation / 360) * 6;
            handsConfiguration.hourHandRotation = (time.Hours % 24 + handsConfiguration.minuteHandRotation / 360) * 30;
            return handsConfiguration;
        }
    }
}