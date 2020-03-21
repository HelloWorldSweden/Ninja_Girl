using System.Collections;
using UnityEngine;


namespace NinjaGirl
{
    [CreateAssetMenu(fileName = "JumpAbility", menuName = "NINJA/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float jumpForce;

        public override void OnStart(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
        }

        public override void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);
            if (_charMovement.jump && !_charMovement.onLadder)
            {

                anim.SetBool(TransitionParameter.Grounded.ToString(), false);
                _charMovement.Rigid.AddForce(Vector2.up * jumpForce);
                anim.SetBool(TransitionParameter.Jump.ToString(), true);

            }
            else
            {
                return;
            }

        }

        public override void OnExit(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
        }

        
    }

}
