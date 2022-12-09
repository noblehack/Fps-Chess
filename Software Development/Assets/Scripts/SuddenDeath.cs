using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuddenDeath : MonoBehaviour
{
    public Slider Timer;
    public GameObject walls;
    public GameObject player1;
    public GameObject player2;
    public static float TimerValue;
    public static bool reset = false;
    public GameObject wallFloor;
    public static float testInt = 30f;
    public AudioSource battleMusic;
    public AudioSource gameMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (!walls.activeSelf)
      battleMusic.Stop();
        
         testInt -= Time.deltaTime;
            Timer.value = testInt;

            if (walls.activeSelf){
               if (walls.transform.localScale.x > .03f)
               walls.transform.localScale = new Vector3(walls.transform.localScale.x-.001f,walls.transform.localScale.y,walls.transform.localScale.z);
            }
 
 if (Timer.value<= 0.0f)
 {
    timerEnded();
 }
     
    }
    public void timerEnded(){
          PlayerMovement playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (!walls.activeSelf && !playerScript.animating ){
         wallFloor.SetActive(true);
         gameMusic.Stop();
        walls.SetActive(true);
        battleMusic.Play();
        player1.transform.position = new Vector3(80,200,25);
        player2.transform.position = new Vector3(70,200,25);
        testInt = 30;
        }
    }
   
     
}
