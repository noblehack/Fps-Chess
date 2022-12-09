using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu2 : MonoBehaviour
{
    public GameObject menu;
   
    public GameObject playerGun;
    public GameObject sword;
    public  Animator swing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetButtonDown ( "ControllerB")&& Swing2.canSwing ){
                if (menu.activeSelf == false){
                menu.SetActive(true);
                } else{
                    menu.SetActive(false);
                }
            }
        if (Input.GetButtonDown("ControllerY") && Swing2.canSwing ){
                if (sword.activeSelf){
                sword.SetActive(false);
                playerGun.SetActive(true);
                } else if (playerGun.activeSelf){
                    playerGun.SetActive(false);
                    sword.SetActive(true);
                } 
            Debug.Log("y clicked");
        }
    //     if (Input.GetButtonDown("ControllerB")){
    //         if (menu.activeSelf == false){
    //             // Cursor.lockState = CursorLockMode.None;
    //              playerGun.SetActive(false);
    //              sword.SetActive(false);
    //              Shoot.canShoot = false;
    //     menu.SetActive(true);
    //         }else{
    //              Cursor.lockState = CursorLockMode.Locked;
    //             menu.SetActive(false);
                
                 
          
    //     }
    // }
     }

    public void onSwordClick(){
        Debug.Log("sword clicked");
        sword.SetActive(true);
         menu.SetActive(false);
         Cursor.lockState = CursorLockMode.Locked;
         Swing.canSwing= true;
    }
    public void onPlayerGunClick(){
         Debug.Log("gun clicked");
         playerGun.SetActive(true);
          menu.SetActive(false);
          Cursor.lockState = CursorLockMode.Locked;
           Shoot.canShoot = true;
    }
}

