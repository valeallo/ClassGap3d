using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string item_name;
    
    // Start is called before the first frame update
    void Start()
    {
        if (item_name == "") 
        { 
            item_name = "Default";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //collect

        other.GetComponent<Player>()?.PickupItem(this);
        gameObject.SetActive(false);

    }
}
