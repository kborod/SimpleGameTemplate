using System;
using UnityEngine;

namespace Kborod.UI.UIScreenManager.Transitions
{
    public abstract class TransitionGetterBase : MonoBehaviour, ITransitionable
    {
        public abstract ITransition Transition { get; }
    }
}