using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NinjaGirl
{
    public abstract class StateData : ScriptableObject
    {
        public abstract void OnStart(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo);
        public abstract void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo);
        public abstract void OnExit(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo);

    }

}
