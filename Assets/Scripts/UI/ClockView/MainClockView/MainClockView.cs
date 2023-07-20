using System;
using TMPro;
using UnityEngine;

namespace Clock.UI.ClockView
{
    public class MainClockView : ClockView
    {
        [SerializeField] private TextMeshProUGUI electronicClock;
        
        protected override void SetElectronicClockValue(TimeSpan time)
        {
            electronicClock.text = time.ToString(@"hh\:mm\:ss");
        }
    }
}