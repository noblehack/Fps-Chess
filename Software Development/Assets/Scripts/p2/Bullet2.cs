using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
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
        

       Debug.Log("anything");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        PlayerMovement playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
         p2Movement ps2 =  GameObject.Find("Player2").GetComponent<p2Movement>();

            if(collision.gameObject.tag =="p1") {
               Debug.Log("p1 was smacked");
                PlayerMovement ps1 =  GameObject.Find("Player").GetComponent<PlayerMovement>();
                ps1.DecreaseHealth(50);
                return;
            }

            //power UPSSSSS!!!!!!!!!!!!!!!!!!!!
            if (collision.gameObject.name == "WKn2" || collision.gameObject.name == "WKn1" ){
           // Debug.Log("king was hit");
           ps2.speedBoost(.64f);
        }
        Debug.Log(collision.gameObject.name.Substring(0,2));
        if (collision.gameObject.name.Length > 2){
        if (collision.gameObject.name.Substring(0,3) == "WPa"){
                ps2.jumpBoost(3f);
               
        }}




        Instantiate(explosionFx, gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(gameObject);
    }
}
