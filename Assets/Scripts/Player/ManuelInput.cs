using System.Collections;
using UnityEngine;


namespace NinjaGirl
{
    public class ManuelInput : MonoBehaviour
    {
        private Movement _charMovement;

        private void Awake()
        {
            _charMovement = gameObject.GetComponent<Movement>();
        }

        // Update is called once per frame
        void Update()
        {
            if(VirtualInputManager.Instance.moveRight)
            {
                _charMovement.moveRight = true;
            }
            else
            {
                _charMovement.moveRight = false;
            }

            if(VirtualInputManager.Instance.moveLeft)
            {
                _charMovement.moveLeft = true;
            }
            else
            {
                _charMovement.moveLeft = false;
            }

            if(VirtualInputManager.Instance.jump)
            {
                _charMovement.jump = true;

            }
            else
            {
                _charMovement.jump = false;
            }

            if(VirtualInputManager.Instance.attacking)
            {
                _charMovement.attacking = true;
            }
            else
            {
                _charMovement.attacking = false;
            }

            if(VirtualInputManager.Instance.moveUp)
            {
                _charMovement.moveUp = true;
            }
            else
            {
                _charMovement.moveUp = false;
            }

            if(VirtualInputManager.Instance.moveDown)
            {
                _charMovement.moveDown = true;
            }
            else
            {
                _charMovement.moveDown = false;
            }

        }

        IEnumerator LiteDelayForJump()
        {
            yield return new WaitForSeconds(0.1f);

        }

    }

}
