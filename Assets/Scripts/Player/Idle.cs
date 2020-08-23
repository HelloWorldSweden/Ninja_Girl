using UnityEngine;

namespace NinjaGirl
{
    [CreateAssetMenu(fileName = "NewAbility", menuName = "NINJA/AbilityData/Idle")]
    public class Idle : StateData
    {
        public override void OnStart(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            anim.SetBool(TransitionParameter.Jump.ToString(), false);
            anim.SetBool(TransitionParameter.Move.ToString(), false);
            anim.SetBool(TransitionParameter.Grounded.ToString(), true);
            anim.SetBool(TransitionParameter.Attack.ToString(), false);

            Movement _charMovement = sb.GetCharMovement(anim);
            if (!_charMovement.climb)
            {
                _charMovement.Rigid.gravityScale = 1;
            }
        }

        public override void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);

            if (_charMovement.moveRight && _charMovement.moveLeft)
            {
                return;
            }

            if (_charMovement.moveRight)
            {
                anim.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (_charMovement.moveLeft)
            {
                anim.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (_charMovement.attacking)
            {
                anim.SetBool(TransitionParameter.Attack.ToString(), true);
            }

            if (_charMovement.climb && (_charMovement.moveUp || _charMovement.moveDown))
            {
                anim.SetBool(TransitionParameter.ClimbIdle.ToString(), true);
            }

        }
        public override void OnExit(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
        }
    }
}

