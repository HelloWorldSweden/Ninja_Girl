using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Transform pointA, pointB;

    // Start is called before the first frame update
    void Start()
    {

    }


    public virtual void Attack()
    {

    }


    // Update is called once per frame
    public abstract void Update();

}
