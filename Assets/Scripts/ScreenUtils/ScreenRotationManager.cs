using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Clock.ScreenUtils
{
    public class ScreenRotationManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> objectsToReparent;
        [SerializeField] private VerticalLayoutGroup verticalLayout;
        [SerializeField] private HorizontalLayoutGroup horizontalLayout;
        private ScreenOrientation currentScreenOrientation;
        private Layout currentLayount;
        
        private enum Layout
        {
            Vertical,
            Horizontal
        }

        private void Start()
        {
            currentScreenOrientation = Screen.orientation;
            if (currentScreenOrientation == ScreenOrientation.Portrait
                || currentScreenOrientation == ScreenOrientation.PortraitUpsideDown)
            {
                SetLayout(Layout.Vertical);
            }
            else
            {
                SetLayout(Layout.Horizontal);
            }
        }

        private void Update()
        {
            currentScreenOrientation = Screen.orientation;
            if (currentLayount == Layout.Horizontal && (currentScreenOrientation == ScreenOrientation.Portrait 
                                                        || currentScreenOrientation == ScreenOrientation.PortraitUpsideDown))
            {
                SetLayout(Layout.Vertical);
            }
            else if (currentLayount == Layout.Vertical && (currentScreenOrientation == ScreenOrientation.LandscapeLeft
                                                           || currentScreenOrientation == ScreenOrientation.LandscapeRight))
            {
                SetLayout(Layout.Horizontal);
            }
        }

        private void SetLayout(Layout layout)
        {
            currentLayount = layout;
            foreach (var obj in objectsToReparent)
            {
                if (layout == Layout.Vertical)
                {
                    obj.transform.parent = verticalLayout.transform;
                }
                else
                {
                    obj.transform.parent = horizontalLayout.transform;
                }
            }
            if (layout == Layout.Vertical)
            {
                verticalLayout.transform.SetSiblingIndex(1);
            }
            else
            {
                horizontalLayout.transform.SetSiblingIndex(1);
            }
        }
    }
}