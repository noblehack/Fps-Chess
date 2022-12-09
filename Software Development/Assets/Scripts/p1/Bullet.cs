using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject explosionFx;
    public GameObject menu1;
    public GameObject menu2;
    public GameObject player1;
    public GameObject p1Sword;
    public GameObject p1Gun;

    
    
    
    // Start is called before the first frame update
    void Start()
    {

        menu1 = GameObject.Find("Menu");
        menu2 = GameObject.Find("Canvas");
        player1 = GameObject.Find("Player Model");
        p1Sword = GameObject.Find("LukeSkywalker'sLightsaber");
        p1Gun = GameObject.Find("Gun");
    
    }

    // Update is called once per frame
    void Update()
    {    
      
    }

    void OnCollisionEnter(Collision collision) {
        PlayerMovement playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
         p2Movement ps2 =  GameObject.Find("Player2").GetComponent<p2Movement>();

        //powerups
        if (collision.gameObject.name == "BKn2" || collision.gameObject.name == "BKn1" ){
           // Debug.Log("king was hit");
           playerScript.speedBoost(24);
        }
        Debug.Log(collision.gameObject.name.Substring(0,2));
        if (collision.gameObject.name.Length > 2){
        if (collision.gameObject.name.Substring(0,3) == "BPa"){
                playerScript.jumpBoost(3f);
               
        }}


       if(collision.gameObject.tag =="p2") {
                ps2.DecreaseHealth(50);
                return;
            }

        Instantiate(explosionFx, gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(gameObject);
    }
   
}
