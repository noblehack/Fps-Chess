using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public  Animator swing;
    public GameObject SwordObject;
    public Rigidbody sword;
   public Transform p1;
   public static bool canSwing = true;
   public float swordDelay = 1.5f;
   public AudioSource SwingSound;
       public GameObject menu1;
    public GameObject menu2;
    public GameObject player1;
    
    // Start is called before the first frame update
    void Start()
    {
          menu1 = GameObject.Find("Menu");
        menu2 = GameObject.Find("Canvas");
        player1 = GameObject.Find("Player Model");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canSwing){
    swing.SetTrigger("Swing");
    StartCoroutine(swordSound());
     SwordObject.GetComponent<Collider>().enabled = true;
    canSwing = false;
    StartCoroutine(swordWait());
    }
        
    }
    public void OnCollisionEnter(Collision collision) {
 PlayerMovement playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();


        Debug.Log(collision.gameObject.name);

        if(collision.gameObject.tag =="p2") {
               Debug.Log("p2 was smacked");
                p2Movement ps2 =  GameObject.Find("Player2").GetComponent<p2Movement>();
                ps2.DecreaseHealth(50);
                return;
            }

        //take damage
        if(collision.gameObject.name.Length == 9) {
            if(collision.gameObject.name == "DamageBox") {
                playerScript.DecreaseHealth(90);
            }
        }

       
    }
     IEnumerator swordWait(){ //-ADDED
        yield return new WaitForSeconds(swordDelay);
         canSwing = true;
        SwordObject.GetComponent<Collider>().enabled = false;
     }
     IEnumerator swordSound(){
        yield return new WaitForSeconds(.5f);
        SwingSound.Play();
     }
}
