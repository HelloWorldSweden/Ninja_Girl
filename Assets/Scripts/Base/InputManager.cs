using UnityEngine;

namespace NinjaGirl
{
    public class InputManager : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.moveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.moveLeft = false;
            }

            if(Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.moveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.moveRight = false;
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                VirtualInputManager.Instance.jump = true;
            }
            else
            {
                VirtualInputManager.Instance.jump = false;
            }
            
            if(Input.GetKeyDown(KeyCode.F))
            {
                VirtualInputManager.Instance.attacking = true;
            }
            else
            {
                VirtualInputManager.Instance.attacking = false;
            }

            if(Input.GetKey(KeyCode.W))
            {
                VirtualInputManager.Instance.moveUp = true;
            }
            else
            {
                VirtualInputManager.Instance.moveUp = false;
            }

            if(Input.GetKey(KeyCode.S))
            {
                VirtualInputManager.Instance.moveDown = true;
            }
            else
            {
                VirtualInputManager.Instance.moveDown = false;
            }
        }
    }
}

