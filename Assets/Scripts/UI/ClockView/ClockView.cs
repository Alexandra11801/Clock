using System;
using Clock.Utils;
using UnityEngine;

namespace Clock.UI.ClockView
{
    public abstract class ClockView : MonoBehaviour
    {
        [SerializeField] protected GameObject hourHand;
        [SerializeField] protected GameObject minuteHand;
        [SerializeField] protected GameObject secondHand;

        public virtual void SetTime(TimeSpan time)
        {
            var handsConfiguration = TimeConvertingUtils.TimeToHandsConfiguration(time);
            hourHand.transform.rotation = Quaternion.Euler(Vector3.back * handsConfiguration.hourHandRotation);
            minuteHand.transform.rotation = Quaternion.Euler(Vector3.back * handsConfiguration.minuteHandRotation);
            secondHand.transform.rotation = Quaternion.Euler(Vector3.back * handsConfiguration.secondHandRotation);
            SetElectronicClockValue(time);
        }

        protected abstract void SetElectronicClockValue(TimeSpan time);
    }
}