using System;
using TMPro;
using UnityEngine;

namespace Clock.UI.ClockView.SetupAlarm
{
    public class ElectronicClockInputField : MonoBehaviour
    {
        [SerializeField] private ElectronicClockInputForm form;
        [SerializeField] private TMP_InputField inputField;
        private int minValue;
        private int maxValue;

        public TMP_InputField InputField => inputField;

        public void OnEndEdit()
        {
            inputField.text = Math.Clamp(Int32.Parse(inputField.text), minValue, maxValue).ToString("00");
            form.UpdateTime();
        }

        public void SetClampValues(int min, int max)
        {
            minValue = min;
            maxValue = max;
        }
    }
}