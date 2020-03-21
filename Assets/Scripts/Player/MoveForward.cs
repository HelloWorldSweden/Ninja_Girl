using UnityEngine;


namespace NinjaGirl
{
    [CreateAssetMenu(fileName = "NewAbility", menuName = "NINJA/AbilityData/MoveForward")]
    public class MoveForward : StateData
    {
        public float speed;
        public AnimationCurve animCurve;

        public override void OnStart(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);
            anim.SetBool(TransitionParameter.ClimbIdle.ToString(), false);
            _charMovement.Rigid.gravityScale = 1;
            
        }

        public override void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMovement = sb.GetCharMovement(anim);
            //float hAxis = Input.GetAxisRaw("Horizontal");


            if (!_charMovement.moveLeft && !_charMovement.moveRight)
            {
                anim.SetBool(TransitionParameter.Move.ToString(), false);
                anim.SetBool(TransitionParameter.Jump.ToString(), false);
                _charMovement.jump = false;
                return;
            }

            if(_charMovement.moveRight && _charMovement.moveLeft)
            {
                anim.SetBool(TransitionParameter.Move.ToString(), false);
                anim.SetBool(TransitionParameter.Jump.ToString(), false);
                _charMovement.jump = false;
                return;
            }

            
            if (_charMovement.moveRight && !_charMovement.moveLeft)
            {
                _charMovement.SR.flipX = false;
                _charMovement.transform.Translate((speed * Time.deltaTime * animCurve.Evaluate(animStateInfo.normalizedTime)), 0, 0);
                // _charMovement.Rigid.velocity = new Vector2((hAxis * speed * Time.deltaTime), _charMovement.Rigid.velocity.y);
            }
           
            if (_charMovement.moveLeft && !_charMovement.moveRight)
            {
                _charMovement.SR.flipX = true;
                _charMovement.transform.Translate((-speed * Time.deltaTime * animCurve.Evaluate(animStateInfo.normalizedTime)), 0, 0);
               //_charMovement.Rigid.velocity = new Vector2((hAxis * speed * Time.deltaTime), _charMovement.Rigid.velocity.y);
            }
            
        }

        public override void OnExit(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
        }
    }

}

