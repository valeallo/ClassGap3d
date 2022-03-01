using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  RaycastWeapon : MonoBehaviour
{
    public GameObject gun_end;
    public Transform hip_position;
    public Transform scoped_position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ToggleScope();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponentInChildren<Animator>().SetTrigger("Shoot");

            RaycastHit hit;
            if (Physics.Raycast(gun_end.transform.position, gun_end.transform.forward, out hit, 20f))
            {   if (hit.transform.GetComponent<Rigidbody>() != null)
                {    
                    hit.transform.GetComponent<Rigidbody>().AddForceAtPosition(gun_end.transform.forward * 100f, hit.point);
                    try 
                    {
                        int exp = 0;
                       if ( hit.transform.GetComponent<Enemy>().TakeDamage(5, out exp))
                        {
                            GetComponentInParent<Player>().AddExp(exp);
                            GetComponentInParent<Player>().AddPoints(10);
                        }
                    }
                    catch
                    {
                        Debug.Log("Raycast hit non-enemy target");
                    }
                }
            }
            Debug.DrawLine(gun_end.transform.position, gun_end.transform.position + gun_end.transform.forward * 20f, Color.red, 1f);
        }
        
     
    }


    void ToggleScope()
    { 
    
        if(transform.position == scoped_position.position)
        {
            transform.position = hip_position.position;

        }
        else
        {

            transform.position = scoped_position.position;
        }
    
    }
}
