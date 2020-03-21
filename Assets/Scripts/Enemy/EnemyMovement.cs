using UnityEngine;


namespace NinjaGirl
{
    public enum EnemyAnimationTransition
    {
        Idle,
        Attacking,
    }

    public abstract class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        protected int enemyHealth;
        [SerializeField]
        protected int speed;
        [SerializeField]
        protected Transform pointA, pointB;
        protected Vector3 currentTarget;

        private Movement _playerMovement;

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


        private void Start()
        {
            _playerMovement = FindObjectOfType<Movement>();
        }

        public virtual void Movement()
        {
            if (transform.position == pointA.position)
            {
                currentTarget = pointB.position;

                Anim.SetTrigger(EnemyAnimationTransition.Idle.ToString());
            }
            else if (transform.position == pointB.position)
            {
                currentTarget = pointA.position;

                Anim.SetTrigger(EnemyAnimationTransition.Idle.ToString());
            }

            if (currentTarget == pointA.position)
            {
                SR.flipX = true;
            }
            else if (currentTarget == pointB.position)
            {

                SR.flipX = false;
            }

            //Moving.
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);


            //Vector3 direction = _playerMovement.transform.localPosition - transform.localPosition;



            //if (direction.x > 0 )
            //{
            //    SR.flipX = false;
            //}

            //else if (direction.x < 0)
            //{
            //    SR.flipX = true;
            //}

        }

        public virtual void Update()
        {

            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("IdleAnim"))
            {

                return;
            }
            Movement();

        }


    }

}
