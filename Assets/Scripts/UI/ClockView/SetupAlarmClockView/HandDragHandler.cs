using System;
using Clock.UI.ClockView.SetupAlarm;
using Clock.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Clock.UI.ClockView
{
    public class HandDragHandler : MonoBehaviour, IDragHandler
    {
        [SerializeField] private GameObject hand;
        [SerializeField] private SetupAlarmClockView clockView;
        [SerializeField] private int divisionsCount;
        private float minimalDragAngle;

        private void Awake()
        {
            minimalDragAngle = 360f / divisionsCount;
        }

        public void OnDrag(PointerEventData eventData)
        {
            var dragAngle = MathUtils.SignedAngle(transform.up, 
                (Vector3)eventData.position - hand.transform.position, Vector3.back);
            if (Mathf.Abs(dragAngle) >= minimalDragAngle)
            {
                var dragDivisionsCount = Mathf.Round(dragAngle / minimalDragAngle);
                clockView.SetTime(clockView.AlarmSetupManager.SetUpTime + TimeSpan.FromSeconds(dragDivisionsCount));
            }
        }
    }
}