using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p2Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerTransform;
    public bool animating = false;
    public Vector3 animationVector = Vector3.zero;
    public int frameCount = 0;
    public Transform animationPosition;
    public float rotationVector = 0f;

    public bool whiteTurn;
    
    public float speed = .32f;
    public float gravity = -12f;

    public static int health = 100;
    public static int shield = 100;
    public Slider healthSlider;
    public Slider shieldSlider;
//
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public float jumpHeight = 1.3f;
    public Transform cameraRotation;
    public AudioSource walk; //ADDED
    public AudioSource walk2;
    Vector3 move = new Vector3(0,0,0);
    float tempx = 0;
    float tempz = 0;
public bool canTakeDamage = true;
    Vector3 velocity;
    bool isGrounded;

     public Animator walkAnimator;

    // Start is called before the first frame update
    void Start()
    {
         speed = .32f   ;
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetAxis("Horizontal2") !=0 ||  Input.GetAxis("Vertical2") !=0){
            walkAnimator.SetBool("walk",true);
           if (walk.isPlaying == false && walk2.isPlaying == false){
                int randomInt = (Random.Range(0, 2));
                if (randomInt == 1){
                    walk.Play();
                } else{
                    walk2.Play();
                }

            
           }
        } else{
             walkAnimator.SetBool("walk",false);
            walk.Stop();
            walk2.Stop();
        }



        if(!animating) {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0) {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal2");
            float z = Input.GetAxis("Vertical2");
           //speed = .32f ;
            tempx = tempx+x;
            tempz = tempz + z;

            if (tempz > 25)
            tempz = 25;
              if (tempz < -25)
            tempz = -25;
            if (tempx > 25)
            tempx = 25;
              if (tempx < -25)
            tempx = -25;

            if (x == 0)
            tempx = tempx/1.5f;
          if (z == 0)
            tempz = tempz/1.5f;
    
            if(Input.GetButtonDown("Jump2") && isGrounded) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            
             move = (transform.right * tempx +  transform.forward * tempz);
             
            
            controller.Move( move * speed * Time.deltaTime);
            velocity.x = controller.velocity.x;
            velocity.z = controller.velocity.z;
            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        } else if(frameCount < 180) {
            playerTransform.position = new Vector3(playerTransform.position.x + animationVector.x, playerTransform.position.y + animationVector.y, playerTransform.position.z + animationVector.z);

            if(cameraRotation.eulerAngles.x < 89f || cameraRotation.eulerAngles.x > 91f)
                cameraRotation.rotation = Quaternion.Euler(cameraRotation.eulerAngles.x + rotationVector, 0f, 0f);

            frameCount++;

            if(frameCount == 180) {
                playerTransform.position = new Vector3(animationPosition.position.x, animationPosition.position.y, animationPosition.position.z);
                cameraRotation.rotation = Quaternion.Euler(90f, 0f, 0f);

                Camera.main.orthographic = true;
                Camera.main.orthographicSize = 50f;
                Cursor.lockState = CursorLockMode.None;

                frameCount++;
            }
        }
    }

    public void ResetPosition() {
        playerTransform.position = new Vector3(0f, 0f, 0f);
    }

    public void CheckTurn(GameObject triggerBox) {
        whiteTurn = triggerBox.name.Substring(10,1) == "W";
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
    }  canTakeDamage = false;
        StartCoroutine(DamageWait());
   
        }
    IEnumerator DamageWait(){
        yield return new WaitForSeconds(0.5f);
        canTakeDamage = true;
     }


        public void speedBoost(float num){
        speed = num;
        StartCoroutine(speedReset());
     }
    IEnumerator speedReset(){
        yield return new WaitForSeconds(10f);
        speed = .32f;
    }
    public void jumpBoost(float num){
        jumpHeight = num;
        StartCoroutine(jumpReset());
    }
    IEnumerator jumpReset(){
         yield return new WaitForSeconds(10f);
        jumpHeight = 1.3f;
    }

}
