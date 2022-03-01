using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public GameObject gun_end;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Fire1")) 
        {
            GameObject p = Instantiate(projectile, gun_end.transform.position, Quaternion.identity);
            p.GetComponent<Rigidbody>().AddForce(gun_end.transform.forward * 200f);//1000f is the magnitude for the direction

            //Capital are function or Class lowercase is a variable or an instance of a class the lowercase is 
        }
    }
}
