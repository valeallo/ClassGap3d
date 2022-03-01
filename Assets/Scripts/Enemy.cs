using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Agent
{
    private int viewcone_stage = 0;
    private GameObject player;
    private NavMeshAgent nav_agent;
    private int exp_reward = 10;

    
    // Start is called before the first frame update
    protected override void Start()
    {
        nav_agent = GetComponent<NavMeshAgent>();
        
    
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (player != null)
        {
            //Vector3 direction = (player.transform.position - transform.position).normalized;
            //Quaternion rotation = Quaternion.LookRotation(direction);
            //Quaternion current_rotation = Quaternion.RotateTowards(transform.rotation, rotation, turn_speed * Time.deltaTime);
            //transform.rotation = current_rotation;
            //transform.Translate(transform.forward * Time.deltaTime * move_speed, Space.World);

            nav_agent.SetDestination(player.transform.position);

            if(Vector3.Distance(transform.position, player.transform.position)<2)
            {
                GetComponentInChildren<Animator>().SetTrigger("Attack");

            }

        }

        else
        {
            ViewCone();
        }
    }


    private void ViewCone(float fov = 90, int rays = 10, int stages = 3, float view_distance = 10)
    {
        float ray_space = fov / rays;
        if (viewcone_stage > 0) 
        {
            rays--;
        
        }

        RaycastHit hit;
        float start_angle = -fov/2 + (ray_space/ stages) * viewcone_stage;
        for (int i = 0; i <= rays; i++)
        {
            Vector3 ray_direction = Quaternion.AngleAxis(start_angle + ray_space * i, transform.up) * transform.forward;
            if (Physics.Raycast(transform.position, ray_direction, out hit, view_distance))
            {
                if (hit.transform.GetComponent<Player>() != null)

                {
                    player = hit.transform.GetComponent<Player>().gameObject;

                }

            }
            Debug.DrawLine(transform.position, transform.position + ray_direction * view_distance, Color.black);
        }
        viewcone_stage++;

        if (viewcone_stage >= stages) 
        {

            viewcone_stage = 0;
        }
    }
    protected override void Die()
    {
        base.Die();
        player = null;
        health_bar.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(1, out int e);
        }
    }


    public override bool TakeDamage(int d, out int exp)
    {
        bool dead =  base.TakeDamage(d, out exp);
        exp = exp_reward;
        return dead;


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //   if (other.GetComponent<Player>() != null) { player = other.GetComponent<Player>().gameObject; }

    //}

    // private void OnTriggerExit(Collider other)
    //{
    //if (other.GetComponent<Player>() == null) { player = other.GetComponent<Player>().gameObject; }

    //}
}



//nav mesh agent allows you to move around the things and around the objects