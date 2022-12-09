using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
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
        if (Input.GetKeyDown("f")&& Swing.canSwing){
            if (menu.activeSelf == false){
                // Cursor.lockState = CursorLockMode.None;
                 Shoot.canShoot = false;
        menu.SetActive(true);
            }else{
                 Cursor.lockState = CursorLockMode.Locked;
                menu.SetActive(false);
                
                 
          
        }
    }
        if (Input.GetKeyDown("g") &&Swing.canSwing){
            if (sword.activeSelf){
                sword.SetActive(false);
                playerGun.SetActive(true);
                 Shoot.canShoot = true;
                } else if (playerGun.activeSelf){
                    playerGun.SetActive(false);
                    sword.SetActive(true);
                } 
                if (!sword.activeSelf && !playerGun.activeSelf){
                    playerGun.SetActive(true);
                     Shoot.canShoot = true;
                }
        }

         if (Input.GetKeyDown("c") && menu.activeSelf){

         }
    
    
    }

    // public void onSwordClick(){
        
    //     Debug.Log("sword clicked");
    //     sword.SetActive(true);
    //      menu.SetActive(false);
    //      Cursor.lockState = CursorLockMode.Locked;
    //      Swing.canSwing= true;
    // }
    // public void onPlayerGunClick(){
    //      Debug.Log("gun clicked");
    //      playerGun.SetActive(true);
    //       menu.SetActive(false);
    //       Cursor.lockState = CursorLockMode.Locked;
    //        Shoot.canShoot = true;
    // }
}
