using System;
using UnityEngine;
using UnityEngine.Events;

namespace Jam.Actions
{
    /// Helper container
    [Serializable]
    public class ActionBaseParams
    {
        [Serializable]
        public class ActionCompleteEvent : UnityEvent<ActionBase> { }

        [SerializeField]
        public ActionCompleteEvent completeHandler = new ActionCompleteEvent();

        [Tooltip("Execute this action manually")]
        public bool execute = false;

        [Tooltip("Is this action currently executing?")]
        public bool active = false;

        /// Trigger events when this action is complete
        public ActionCompleteEvent onComplete
        {
            get { return completeHandler; }
            set { completeHandler = value; }
        }
    }

    /// Base type for all actions to inherit from
    public class ActionBase : MonoBehaviour
    {
        public ActionBaseParams action;

        /// On update do nothing except check if we need to run some action and run it if so.
        /// Otherwise perform an animation update if required.
        public void Update()
        {
            if (action.execute)
            {
                action.execute = false;
                action.active = true;
                Execute();
            }
            if (action.active)
            {
                Step(Time.deltaTime);
            }
        }

        /// Invoke this when the action is done
        protected void Complete()
        {
            action.active = false;
            action.completeHandler.Invoke(this);
        }

        /// Execute this action explicitly via a callback
        protected virtual void Execute()
        {
        }

        /// Step for the animation
        protected virtual void Step(float delta)
        {
        }
    }
}
