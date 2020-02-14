using UnityEngine;

namespace NinjaGirl
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        Grounded,
        Attack,
        Climb,
    }

    public class Movement : MonoBehaviour
    {

        public bool moveRight;
        public bool moveLeft;
        public bool moveUp;
        public bool moveDown;
        public bool jump;
        public bool attacking;
        public bool grounded;
        public bool isAlive = true;
        public bool climb;
        public Transform rayPos;

        private Animator _anim;
        public Animator Anim
        {
            get
            {
                if(_anim == null)
                {
                    _anim = GetComponentInChildren<Animator>();
                }
                return _anim;
            }
        }

        private SpriteRenderer _sr;
        public SpriteRenderer SR
        {
            get
            {
                if (_sr == null)
                {
                    _sr = GetComponentInChildren<SpriteRenderer>();
                }
                return _sr;
            }
        }

        private Rigidbody2D _rb;
        public Rigidbody2D Rigid
        {
            get
            {
                if (_rb == null)
                {
                    _rb = GetComponent<Rigidbody2D>();
                }
                return _rb;
            }
        }

    }

}
