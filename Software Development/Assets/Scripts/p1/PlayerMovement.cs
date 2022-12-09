using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerTransform;
    public bool animating = false;
    public Vector3 animationVector = Vector3.zero;
    public int frameCount = 0;
    public Transform animationPosition;
    public float rotationVector = 0f;
    public GameObject p1Turn;
     public GameObject p2Turn;
    public bool whiteTurn;
    
    public float speed = 12;
    public float gravity = -20f;

    public static int health = 100;
    public static int shield = 100;
    public Slider healthSlider;
    public Slider shieldSlider;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public float jumpHeight = 2f;
    public Transform cameraRotation;
    public AudioSource walk; //ADDED
    public AudioSource walk2;
    public Animator walkAnimator;
public bool canTakeDamage = true;
    Vector3 velocity;
    bool isGrounded;
  public Collider player1Body;
  public GameObject p1Body;
  public GameObject p1Menu;


    // Start is called before the first frame update
    void Start()
    {
            player1Body = gameObject.GetComponent<BoxCollider>();
               Screen.SetResolution(1920, 540, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i")){
            health = 0;
        }
        if (animating){
            p1Body.SetActive(false);
           player1Body.enabled = (false);
                if (!whiteTurn){
                    p1Turn.SetActive(true);
                } else{
                    p2Turn.SetActive(true);
                }
        } else{
            p1Turn.SetActive(false);
            p2Turn.SetActive(false);
            p1Body.SetActive(true); 
             player1Body.enabled = (true);
        }

        if (Input.GetAxis("Horizontal") !=0 ||  Input.GetAxis("Vertical") !=0){
            walkAnimator.SetBool ("walk", true);
           if (walk.isPlaying == false && walk2.isPlaying == false){
                int randomInt = (Random.Range(0, 2));
                if (randomInt == 1){
                    walk.Play();
                } else{
                    walk2.Play();
                }

            
           }
        } else{
             walkAnimator.SetBool ("walk", false);
            walk.Stop();
            walk2.Stop();
        }



        if(!animating) {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0) {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if(Input.GetButtonDown("Jump") && isGrounded) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            
            Vector3 move = transform.right * x + transform.forward * z;
            
            if (move != Vector3.zero){

            }

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        } else if(frameCount < 180) {
            playerTransform.position = new Vector3(playerTransform.position.x + animationVector.x, playerTransform.position.y + animationVector.y, playerTransform.position.z + animationVector.z);

            if(cameraRotation.eulerAngles.x < 89f || cameraRotation.eulerAngles.x > 91f)
                cameraRotation.rotation = Quaternion.Euler(cameraRotation.eulerAngles.x + rotationVector, 0f, 0f);

            frameCount++;

            if(frameCount == 180) {
                playerTransform.position = new Vector3(animationPosition.position.x, animationPosition.position.y, animationPosition.position.z);
                cameraRotation.rotation = Quaternion.Euler(90,0f,0f);
                if (p1Turn.activeSelf)
                cameraRotation.rotation = Quaternion.Euler(90,180f,0f);
                

               Camera.main.orthographic = true;
                Camera.main.orthographicSize = 42f;
                Cursor.lockState = CursorLockMode.None;

                frameCount++;
            }
        }
            
        if(PlayerMovement.health ==0 || p2Movement.health ==0) {
            p1Menu.SetActive(false);
                if (PlayerMovement.health ==0)
                whiteTurn= true;
                if (p2Movement.health ==0)
                whiteTurn = false;
                health = 100;
             p2Movement.health = 100;

                animating = true;
                animationVector = new Vector3((animationPosition.position.x - playerTransform.position.x)/180f, (animationPosition.position.y -playerTransform.position.y)/180f, (animationPosition.position.z - playerTransform.position.z)/180f);

                if(cameraRotation.eulerAngles.x >= 180f) {
                   rotationVector = (90 - (cameraRotation.eulerAngles.x - 360f))/180f;
                } else {
                    rotationVector = (90 - cameraRotation.eulerAngles.x)/180f;
                
            }
        } 
    }

    public void ResetPosition() {
        playerTransform.position = new Vector3(0f, 0f, 0f);
    }



    public void DecreaseHealth(int healthChange) {
        if (canTakeDamage){
        if(shield >= healthChange) {
            shield -= healthChange;
            shieldSlider.value = shield;
        } else {
            if(shield > 0) {
                healthChange = healthChange - shield;
                shield = 0;
                shieldSlider.value = shield;
            }
            if(healthChange > health) {
                health = 0;
            } else {
                health -= healthChange;
            }
            healthSlider.value = health;
        }
        canTakeDamage = false;
        StartCoroutine(DamageWait());
        }
    }
    IEnumerator DamageWait(){
        yield return new WaitForSeconds(.5f);
        canTakeDamage = true;
     }










     public void speedBoost(float num){
        speed = num;
        StartCoroutine(speedReset());
     }
    IEnumerator speedReset(){
        yield return new WaitForSeconds(10f);
        speed = 12f;
    }
    public void jumpBoost(float num){
        jumpHeight = num;
        StartCoroutine(jumpReset());
    }
    IEnumerator jumpReset(){
         yield return new WaitForSeconds(10f);
        jumpHeight = 2f;
    }

}
