using UnityEngine;


namespace NinjaGirl
{
    [CreateAssetMenu(fileName = "ClimbAbility", menuName = "NINJA/AbilityData/ClimbRight")]
    public class ClimbRight : StateData
    {
        public int speed;

        public override void OnStart(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);
            anim.SetBool(TransitionParameter.ClimbLeft.ToString(), false);
            anim.SetBool(TransitionParameter.CL.ToString(), false);
                     
        }

        public override void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);
                       
            if(_charMovement.onLadder && _charMovement.moveRight)
            {
                _charMovement.transform.Translate((speed * Time.deltaTime), 0, 0);

            }

            if (_charMovement.onLadder && (_charMovement.moveUp || _charMovement.moveDown))
            {
                anim.SetBool(TransitionParameter.Climb.ToString(), true);
            }

            

            if(_charMovement.onLadder && _charMovement.moveLeft)
            {
                anim.SetBool(TransitionParameter.CL.ToString(), true);
            }

            if (!_charMovement.onLadder)
            {
                anim.SetBool(TransitionParameter.ClimbRight.ToString(), false);
            }

            if (_charMovement.moveRight && _charMovement.moveLeft)
            {
                return;
            }

        }

        public override void OnExit(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
        }


    }

}
