using UnityEngine;


namespace NinjaGirl
{
    [CreateAssetMenu(fileName = "ClimbAbility", menuName = "NINJA/AbilityData/ClimbIdle")]
    public class ClimbIdle : StateData
    {
        

        public override void OnStart(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);
           
        }

        public override void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);

            if (_charMovement.moveUp && _charMovement.moveDown)
            {
                return;
            }

            if(!_charMovement.onLadder)
            {
                anim.SetBool(TransitionParameter.ClimbIdle.ToString(), false);
            }

            if(_charMovement.onLadder && (_charMovement.moveUp || _charMovement.moveDown))
            {
                anim.SetBool(TransitionParameter.Climb.ToString(), true);
            }

            if(_charMovement.onLadder && _charMovement.moveLeft)
            {
                anim.SetBool(TransitionParameter.ClimbLeft.ToString(), true);
            }

            if (_charMovement.onLadder && _charMovement.moveRight)
            {
                anim.SetBool(TransitionParameter.ClimbRight.ToString(), true);
            }


        }

        public override void OnExit(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
        }


    }

}
