using UnityEngine;


namespace NinjaGirl
{
    public enum EnemyTransitionParameter
    {
        ToIdle,
        Attacking,
        Run,
    }

    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField]
        protected int enemyHealth;
        [SerializeField]
        protected int speed;
        [SerializeField]
        protected Transform pointA, pointB;

        protected bool isDead = false;
        protected Vector3 currentTarget;
        protected Movement _playerMovement;
        public bool yAttack;

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

        private Animator _anim;
        public Animator Anim
        {
            get
            {
                if (_anim == null)
                {
                    _anim = GetComponentInChildren<Animator>();
                }
                return _anim;
            }
        }

        public virtual void Init()
        {
            _playerMovement = GameObject.FindObjectOfType<Movement>();
        }

        private void Start()
        {
            Init();
        }

        public virtual void Update()
        {
            
            Movement();
        }

        public virtual void Movement()
        {
            if (transform.position.x == pointA.position.x)
            {
                currentTarget = pointB.position;
                Anim.SetTrigger(EnemyTransitionParameter.ToIdle.ToString());
                Anim.SetBool(EnemyTransitionParameter.Run.ToString(), false);
            }
            else if (transform.position.x == pointB.position.x)
            {
                currentTarget = pointA.position;
                Anim.SetTrigger(EnemyTransitionParameter.ToIdle.ToString());
                Anim.SetBool(EnemyTransitionParameter.Run.ToString(), false);

            }

            if (!yAttack)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

            }


            if (currentTarget == pointA.position)
            {
                SR.flipX = true;
            }
            else if (currentTarget == pointB.position)
            {
               
                SR.flipX = false;
            }


            if(_playerMovement.isAlive)
            {
                Vector3 direction = _playerMovement.transform.localPosition - transform.localPosition;

                if (direction.x > 0 && yAttack)
                {
                    SR.flipX = false;
                }

                else if (direction.x < 0 && yAttack)
                {
                    SR.flipX = true;
                }
            }

            

            Anim.SetBool(EnemyTransitionParameter.Run.ToString(), true);
        }


    }
}

