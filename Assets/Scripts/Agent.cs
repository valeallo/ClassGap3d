using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour //this in an abstract class it can not be called directly and attached directly to things 
{
    protected float health = 10;
    protected float move_speed = 10f;
    protected float turn_speed = 360f;
    public ProgressBar health_bar;
    // Start is called before the first frame update

    protected virtual void Awake() //virtual it can be overridden abstract it MUST be overridden
    {
        health_bar.max = health;
        health_bar.current = health;
        health_bar.min = 0;
    }


    //You can be created 

    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual bool TakeDamage(int d, out int exp)
    {
        exp = 0;
        if (health > 0)
        {
            health -= d;
            health_bar.current = health;

            if (health <= 0)
            {
                health = 0;
                Die();
                return true;
            }
        }
        return false;

    }


    protected virtual void Die() 
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
