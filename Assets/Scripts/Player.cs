using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Agent //this player is an agent it takes all the things from agent
{
    
    public Text score_text;
    PlayerData data = new PlayerData();
    public ProgressBar timer_radial;
    private Inventory inventory;
    public ProgressBar exp_bar;

    


    IEnumerator Timer (float time) //IEnumerator is the type for couroutine in unity and it runs things in parallel
    {
        timer_radial.max = time;
        timer_radial.min = 0;
        timer_radial.current = time;
        float remaining_time = time;
        while (remaining_time > 0)
        {
            timer_radial.current = remaining_time;
            yield return new WaitForFixedUpdate(); //FIxedUpdate is once every 0.02 second but I can change it in edit project time at least 60 frames for second all the time, is the limt of a gameconsole
            remaining_time -= Time.fixedDeltaTime;

        }

        //inside the couroutine liam use while (true) is dangerous because in a normal code it will crash in a couroutine if we have a waitforfixed update it will not run continously
        //there is a StopAllcpouroutine and Stop a specific couroutine if we can stop
        //the couroutine strenght is that i will always have something in the background and a WAot in the while loop or it will crash
    }

    protected override void Awake()
    {
        base.Awake();
        inventory = new Inventory();
        ServiceLocator.SetPlayer(this);
        exp_bar.min = 0;
        exp_bar.max = 40;
        exp_bar.current = 0;
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Cursor.lockState = CursorLockMode.Locked; //makes the cursor invisible Confined (it cant leave the game window), locked, unlocked 
        StartCoroutine(Timer(15f));
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        HandleInput();
    }

    public void AddPoints(int p)
    {
        data.score += p;
        score_text.text = data.score.ToString();
    
    }
    void HandleInput()
    {
    if (Input.GetAxis("Vertical")!=0)
    {
         transform.Translate(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * move_speed, Space.World);
    }
    if (Input.GetAxis("Horizontal")!= 0)
    {
        transform.Translate(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * move_speed, Space.World);
    }
    if (Input.GetAxisRaw("Mouse X") != 0)
    {
        transform.Rotate(transform.up, Input.GetAxisRaw("Mouse X") * turn_speed * Time.deltaTime);
    }

    if (Input.GetAxisRaw("Mouse Y") != 0)
    {
        Camera.main.transform.Rotate(Vector3.right, -Input.GetAxisRaw("Mouse Y") * turn_speed * Time.deltaTime);//this rotates the camera cause i don't
    }
    if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, -transform.up, 1.2f))
    {
        GetComponent<Rigidbody>().AddForce(transform.up * 300f);//GatComponent looks for things inside and the we find the player body cause its inside the function and in this case we add a force to that
    }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropNextItem();
        }


    if (Input.GetKeyDown(KeyCode.Alpha1)) { DropItem(0); }
    if (Input.GetKeyDown(KeyCode.Alpha2)) { DropItem(1); }
    if(Input.GetKeyDown(KeyCode.Alpha3)) { DropItem(2); }
    }

    

    protected override void Die()
    {
        base.Die(); //if you want to access the parent in a child class you have to say base 

        SaveSystem.Save(data);
        SceneManager.LoadScene(0);
    }



    public void PickupItem(Item i)
    {
        inventory.PickupItem(i);
        int gold_count = 0;
        foreach(var item in inventory.GetItems()) 
        {
            if (item.item_name == "Gold")
            {

                gold_count++;
            }
        }

        Debug.Log($" {gold_count}gold");
    }    

    private void DropNextItem() 
    {
        DropItem(0);
    
    }
    
    
    
    
    
    private void DropItem(int index)
    { Item i = inventory.DropItem(0);
        if (i == null) { return; } 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, 3f))
        {
            i.transform.position = hit.point + new Vector3(0, 1, 0);

        
        }
        else {
            i.transform.position = transform.position + transform.forward * 2;

                
               }
        i.gameObject.SetActive(true);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Weapon"))
        {
            TakeDamage(1, out int e);
        }
    }

    public void AddExp(int exp)
    {
        data.exp += exp;
        exp_bar.current = data.exp;
        if (exp_bar.current == exp_bar.max)
        {
            exp_bar.min += 40;
            exp_bar.max += 40;
        }

    }
    

}