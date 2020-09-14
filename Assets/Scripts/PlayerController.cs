using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   public float speed = 800.0F;
    public Text scoreText;
    public Text winText;
    public Text time;
    public Text gameOver;
    private float countdown = 10;
    private bool timeIsRunning = false;
    private int count = 0;
    
    private void Start()
    {
        timeIsRunning = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  //use GetAxis instead of getAxis
        float moveVertical = Input.GetAxis("Vertical");      //use GetAxis instead of getAxis

        Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);   
    }

    void Update()
    {
        //Countdown time----
        if (timeIsRunning)
        {
            if (countdown > 0)
            {
                DisplayTime(countdown);
                countdown -= Time.deltaTime;
                //time.text = "" + countdown;
                
            }
            else
            {
                gameOver.gameObject.SetActive(true);
                timeIsRunning = false;
                countdown = 0;
            }
        }
    }

    void DisplayTime(float displayTime)
    {
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);

        time.text = string.Format("Remaining Time: {0:00}:{1:00}", minutes, seconds);
        
        return;
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Pickup")
        {
            obj.gameObject.SetActive(false);
            count += 1;
            scoreText.text = "Score: " + count;
        }
       
        if(count>=16){
            winText.gameObject.SetActive(true);
        }

    }
}
