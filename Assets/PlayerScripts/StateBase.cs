using System.Collections.Generic;
using UnityEngine;


namespace NinjaGirl
{
    public class StateBase : StateMachineBehaviour
    {
        public List<StateData> listAbilityData = new List<StateData>();

        public void UpdateAll(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            foreach (StateData sd in listAbilityData)
            {
                sd.UpdateAbility(sb, anim, animStateInfo);
            }
        }


        private Movement _charMovement;

        public Movement GetCharMovement(Animator anim)
        {
            if (_charMovement == null)
            {
                _charMovement = anim.GetComponentInParent<Movement>();
            }
            return _charMovement;
        }




        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            foreach (StateData enter in listAbilityData)
            {
                enter.OnStart(this, animator, animatorStateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            UpdateAll(this, animator, animatorStateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            foreach (StateData exit in listAbilityData)
            {
                exit.OnExit(this, animator, animatorStateInfo);
            }
        }


        

    }
}

