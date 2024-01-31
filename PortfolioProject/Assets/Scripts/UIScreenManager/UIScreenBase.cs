using Kborod.UI.UIScreenManager.Transitions;
using System;
using UnityEngine;

namespace Kborod.UI.UIScreenManager
{
    public abstract class UIScreenBase : MonoBehaviour
    {
        public Action<UIScreenBase> OnCloseCalled { get; set; }
        public Action<UIScreenBase> OnReleaseCalled { get; set; }

        public virtual ITransition Transition => GetTransition();

        private ITransition GetTransition()
        {
            if (_transition == null)
            {
                var control = GetComponent<TransitionGetterBase>();
                if (control == null)
                    throw new Exception($"{typeof(TransitionGetterBase)} not found on screen {name}");
                _transition = control.Transition;
            }
            return _transition;
        }
        private ITransition _transition;


        [ContextMenu("==CloseScreen==")]
        public virtual void Close()
        {
            OnCloseCalled?.Invoke(this);
        }

        [ContextMenu("==ReleaseScreen==")]
        public virtual void Release()
        {
            OnReleaseCalled?.Invoke(this);
        }
    }
}