using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetAll : MonoBehaviour
{
    public GameObject reset;
      public GameObject menu1;
    public GameObject menu2;
    public GameObject player1;
    public GameObject p1Sword;
    public GameObject p1Gun;
    public Slider healthSlider;
    public Slider shieldSlider;
    public Slider Timer;



    public Slider p2healthSlider;
      public Slider p2ShieldSlider;
      public GameObject p2Menu;
      public GameObject p2Menu2;
      public GameObject p2Gun;
      public GameObject walls;
      public GameObject wallFloor;
      public AudioSource gameMusic;


    // Start is called before the first frame update
    void Start()
    {
      Screen.SetResolution(1920, 540, true);  
    }

    // Update is called once per frame
    void Update()
    {
        if (!reset.activeSelf){
    
        Reset();
        reset.SetActive(true);
        }
        if (Input.GetKeyDown("r")){
            Reset();
        }
    }


    public void Reset(){
      gameMusic.Play();
    walls.SetActive(false);
    walls.transform.localScale = new Vector3(1,1,1);
       wallFloor.SetActive(false);
     SuddenDeath.testInt = 30;
        menu2.SetActive(true);
        player1.SetActive(true);
        healthSlider.value = 100;
        shieldSlider.value=100;
        p2healthSlider.value = 100;
        p2ShieldSlider.value = 100;
        PlayerMovement.health = 100;
        PlayerMovement.shield = 100;
           p2Movement.health = 100;
        p2Movement.shield = 100;
    }//
}
