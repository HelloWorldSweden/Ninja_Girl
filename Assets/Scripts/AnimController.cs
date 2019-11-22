using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump()
    {
        _anim.SetTrigger("jumpTrigger");
    }

    public void ResetJump()
    {
        _anim.SetTrigger("jumpTrigger");
    }

    public void Attack()
    {
        _anim.SetTrigger("attackTrigger");
    }

    public void Climb(bool condi)
    {
       // _anim.SetBool("jumpBool", condi);
    }
}
