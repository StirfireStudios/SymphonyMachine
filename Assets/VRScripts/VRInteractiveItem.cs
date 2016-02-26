using System;
using UnityEngine;

namespace VRStandardAssets.Utils
{
    // This class should be added to any gameobject in the scene
    // that should react to input based on the user's gaze.
    // It contains events that can be subscribed to by classes that
    // need to know about input specifics to this gameobject.
    public class VRInteractiveItem : MonoBehaviour
    {
        public event Action OnOver;             // Called when the gaze moves over this object
        public event Action OnOut;              // Called when the gaze leaves this object
        public event Action OnClick;            // Called when click input is detected whilst the gaze is over this object.
        public event Action OnDoubleClick;      // Called when double click input is detected whilst the gaze is over this object.
        public event Action OnUp;               // Called when Fire1 is released whilst the gaze is over this object.
        public event Action OnDown;             // Called when Fire1 is pressed whilst the gaze is over this object.
        public event Action OnTouch;            // Called when a VRMotionInteractive item touches this object.
        public event Action OnUntouch;          // Called when a VRMotionInteractive item stops touching this object.
        public event Action OnTouchTrigger;     // Called when a VRMotionInteractive item triggers this object.
        public event Action OnTouchTriggerStop; // Called when a VRMotionInteractive item stops triggering this object.

        protected bool m_IsOver;


        public bool IsOver
        {
            get { return m_IsOver; }              // Is the gaze currently over this object?
        }


        // The below functions are called by the VREyeRaycaster when the appropriate input is detected.
        // They in turn call the appropriate events should they have subscribers.
        public void Over()
        {
            m_IsOver = true;

            if (OnOver != null)
                OnOver();
        }


        public void Out()
        {
            m_IsOver = false;

            if (OnOut != null)
                OnOut();
        }


        public void Click()
        {
            if (OnClick != null)
                OnClick();
        }


        public void DoubleClick()
        {
            if (OnDoubleClick != null)
                OnDoubleClick();
        }


        public void Up()
        {
            if (OnUp != null)
                OnUp();
        }


        public void Down()
        {
            if (OnDown != null)
                OnDown();
        }

        public void Touch()
        {
            if (OnTouch != null)
                OnTouch();
        }

        public void Untouch()
        {
            if (OnUntouch != null)
                OnUntouch();
        }

        public void TouchTrigger()
        {
            if (OnTouchTrigger != null)
                OnTouchTrigger();
        }

        public void TouchTriggerStop()
        {
            if (OnTouchTriggerStop != null)
                OnTouchTriggerStop();
        }

#if UNITY_EDITOR

        public enum Event
        { 
            none, On_over, On_out, On_click, On_double_click, On_up, 
            On_down, On_touch, On_untouch, On_touchtrigger, On_untouchtrigger
        }

        public Event eventToTest = Event.none;

        public void Update()
        {
            if (eventToTest == Event.none) return;
            if (eventToTest == Event.On_touch) Touch();    
            if (eventToTest == Event.On_untouch) Untouch();    
            if (eventToTest == Event.On_touchtrigger) TouchTrigger();

            eventToTest = Event.none;
        }

    

#endif

    }
}