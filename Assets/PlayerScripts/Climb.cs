using UnityEngine;


namespace NinjaGirl
{
    [CreateAssetMenu(fileName = "JumpAbility", menuName = "NINJA/AbilityData/Climb")]
    public class Climb : StateData
    {
        public float speed;
       
        public override void OnStart(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);
            _charMovement.Rigid.gravityScale = 0;
        }

        public override void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);
           
            if(_charMovement.moveUp && _charMovement.moveDown)
            {
                anim.SetBool(TransitionParameter.Climb.ToString(), false);
                return;
            }

            if(!_charMovement.moveUp && !_charMovement.moveDown)
            {
                anim.SetBool(TransitionParameter.Climb.ToString(), false);
                return;
            }

            if(_charMovement.moveUp && !_charMovement.moveDown)
            {
                _charMovement.transform.Translate(0, (speed * Time.deltaTime), 0);
            }

            if(!_charMovement.moveUp && _charMovement.moveDown)
            {
                _charMovement.transform.Translate(0, (-speed * Time.deltaTime), 0);
            }

        }

        public override void OnExit(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
        }


    }

}
