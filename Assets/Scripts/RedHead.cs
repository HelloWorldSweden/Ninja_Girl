using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHead : Enemy
{

    private Vector3 _currentTarget;
    private SpriteRenderer _mySprite;
    private Animator _myAnim;


    public override void Update()
    {

        if (_myAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    private void Start()
    {
        _mySprite = GetComponentInChildren<SpriteRenderer>();
        _myAnim = GetComponentInChildren<Animator>();
    }

    void Movement()
    {
        if (_currentTarget == pointA.position)
        {
            _mySprite.flipX = true;
        }
        else if (_currentTarget == pointB.position)
        {
            _mySprite.flipX = false;
        }
        
        

        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _myAnim.SetTrigger("BackToIdle");
            
        }
        else if(transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _myAnim.SetTrigger("BackToIdle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }

   
}
