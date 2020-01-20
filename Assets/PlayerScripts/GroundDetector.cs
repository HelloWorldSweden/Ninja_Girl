using UnityEngine;

namespace NinjaGirl
{
    [CreateAssetMenu(fileName = "NewAbility", menuName = "NINJA/AbilityData/Detector")]
    public class GroundDetector : StateData
    {
        public float distance;

        public override void OnStart(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {

        }

        public override void UpdateAbility(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {
            Movement _charMove = sb.GetCharMovement(anim);

            if (IsGrounded(_charMove))
            {
                anim.SetBool(TransitionParameter.Grounded.ToString(), true);

            }
            else
            {
                anim.SetBool(TransitionParameter.Grounded.ToString(), false);
                return;
            }
        }

        public override void OnExit(StateBase sb, Animator anim, AnimatorStateInfo animStateInfo)
        {

        }

        bool IsGrounded(Movement _charMovement)
        {
            Debug.DrawRay(_charMovement.rayPos.position, Vector2.down, Color.red);

            RaycastHit2D hitInfo = Physics2D.Raycast(_charMovement.rayPos.position, Vector2.down, distance, 1 << 8);
            if (hitInfo.collider != null)
            {
                return true;
            }
            return false;

        }
    }
}

