using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    public Transform endPos;
    public Transform startPos;
    public GameObject bulletPrefab;
    public float bulletForce = 50000f;
    public GameObject player;
    public Animator pistolAnimator;
   
    public GameObject gunfire; //-ADDED (holds gunfire prefab / asset)
    public AudioSource shotsound; //ADDED under gun object
    public float timeBetweenShots = .5f;//ADDED
    public static bool canShoot = true; //ADDED
    public GameObject playerGun;//added
    public int hasAmmo = 10;
    public Slider ammoBar;
    public float reloadTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
//
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        
        if(Input.GetMouseButtonDown(0) && !playerScript.animating &&canShoot &&hasAmmo>0 && playerGun.activeSelf) { //added
          pistolAnimator.SetTrigger("Shoot");
            GameObject bullet = Instantiate(bulletPrefab, startPos.position, startPos.rotation);
            gunfire.SetActive(true); //-ADDED
            StartCoroutine(wait()); //ADDED
            shotsound.Play();//ADDED
            canShoot = false; //ADDED
            hasAmmo--;
            if (hasAmmo <1)
            reload();
            ammoBar.value = hasAmmo;
            StartCoroutine(shootWait());//ADDED
            Vector3 velocity = new Vector3(endPos.position.x - startPos.position.x, endPos.position.y - startPos.position.y, endPos.position.z - startPos.position.z);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(velocity * bulletForce);

            Destroy(bullet, 2f);
          
        }

        MouseLook cameraScript = GameObject.Find("Main Camera").GetComponent<MouseLook>();

        if(Input.GetMouseButton(1) && playerGun.activeSelf) {//added
        
        Camera.main.fieldOfView = 30;
            //playerScript.speed = 6f;
            cameraScript.mouseSensitivity = 100f;
            
        }

        if(!Input.GetMouseButton(1) &&  playerGun.activeSelf ) { //added
           Camera.main.fieldOfView = 75;
           // playerScript.speed = 12f;
            cameraScript.mouseSensitivity = 300f;
           
        }

        
    }
     IEnumerator wait(){ //-ADDED
        yield return new WaitForSeconds(.2f);
         gunfire.SetActive(false); 
     }


     public void reload(){
        StartCoroutine(reloadTimer());
     }
         IEnumerator reloadTimer(){ //-ADDED
        yield return new WaitForSeconds(reloadTime);
         hasAmmo = 10;
         ammoBar.value = hasAmmo;
     }


     IEnumerator shootWait(){ //-ADDED
        yield return new WaitForSeconds(timeBetweenShots);
         canShoot = true;
     }
}
