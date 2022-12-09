using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing2 : MonoBehaviour
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
    public GameObject player2;


    
    
    // Start is called before the first frame update
    void Start()
    {
           
          menu1 = GameObject.Find("Menu2");
        menu2 = GameObject.Find("Canvas2");
        player2 = GameObject.Find("PlayerModel2");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("r2") >0 && canSwing){
    swing.SetTrigger("Swing");
    Debug.Log("trying to swing");
    StartCoroutine(swordSound());
     SwordObject.GetComponent<Collider>().enabled = true;
    canSwing = false;
    StartCoroutine(swordWait());
    }
        
    }
    public void OnCollisionEnter(Collision collision) {
 p2Movement playerScript = GameObject.Find("Player2").GetComponent<p2Movement>();

        //hit trigger boxes
        if(collision.gameObject.name.Length > 10) {
            if(collision.gameObject.name.Substring(0,10) == "TriggerBox") {
                playerScript.CheckTurn(collision.gameObject);
                if(menu1)
                    menu1.SetActive(false);
                if(menu2)
                    menu2.SetActive(false);
                    if (player2)
                    player2.SetActive(false);
                playerScript.animating = true;
                playerScript.animationVector = new Vector3((playerScript.animationPosition.position.x - playerScript.playerTransform.position.x)/180f, (playerScript.animationPosition.position.y - playerScript.playerTransform.position.y)/180f, (playerScript.animationPosition.position.z - playerScript.playerTransform.position.z)/180f);

                if(playerScript.cameraRotation.eulerAngles.x >= 180f) {
                    playerScript.rotationVector = (90 - (playerScript.cameraRotation.eulerAngles.x - 360f))/180f;
                } else {
                    playerScript.rotationVector = (90 - playerScript.cameraRotation.eulerAngles.x)/180f;
                }
            }
        }

        Debug.Log(collision.gameObject.name);

        
            if(collision.gameObject.tag =="p1") {
               Debug.Log("p1 was smacked");
                PlayerMovement ps1 =  GameObject.Find("Player").GetComponent<PlayerMovement>();
                ps1.DecreaseHealth(50);
                return;
            }
        

        //take damage
       
            if(collision.gameObject.name == "DamageBox") {
                playerScript.DecreaseHealth(90);
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
