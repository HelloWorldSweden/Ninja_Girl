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
            anim.SetBool(TransitionParameter.Jump.ToString(), false);
            //anim.SetBool(TransitionParameter.Move.ToString(), false);
            //anim.SetBool(TransitionParameter.Grounded.ToString(), false);
            anim.SetBool(TransitionParameter.Attack.ToString(), false);          
        }

        public override void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);

            if (_charMovement.moveRight && _charMovement.moveLeft)
            {
                anim.SetBool(TransitionParameter.Move.ToString(), false);
                anim.SetBool(TransitionParameter.Jump.ToString(), false);
                _charMovement.jump = false;
                return;
            }

            if (_charMovement.jump && !_charMovement.onLadder)
            {
                anim.SetBool(TransitionParameter.Jump.ToString(), true);
                anim.SetBool(TransitionParameter.Grounded.ToString(), false);
                _charMovement.Rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
