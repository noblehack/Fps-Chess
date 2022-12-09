using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot2 : MonoBehaviour
{
    public Transform endPos;
    public Transform startPos;
    public GameObject bulletPrefab;
    public float bulletForce = 50000f;
    public GameObject player;
    public Animator pistolAnimator;
    public Animator gunAnimator;
    public GameObject gunfire; //-ADDED (holds gunfire prefab / asset)
    public AudioSource shotsound; //ADDED under gun object
    public float timeBetweenShots = .5f;//ADDED
    public static bool canShoot = true; //ADDED
    public GameObject playerGun;//added
    public new Camera camera;
      public int hasAmmo = 10;
    public Slider ammoBar;
    public float reloadTime = 3.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        p2Movement playerScript = player.GetComponent<p2Movement>();
        
        if(Input.GetAxis("r2")>0 &&canShoot && playerGun.activeSelf &&hasAmmo>0) { //added
            gunAnimator.SetTrigger("Shoot");
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

         

        if(Input.GetAxis("l2")>0 && playerGun.activeSelf) {//added     
        camera.fieldOfView = 30;
            //playerScript.speed = 6f;
            p2Look.sensitivity = 1000;
        }

        if(! (Input.GetAxis("l2")>0) &&  playerGun.activeSelf ) { //added 
       camera.fieldOfView = 75;
           // playerScript.speed = 12f;
            p2Look.sensitivity = 2000;
        }
        
    }

     IEnumerator wait(){ //-ADDED
        yield return new WaitForSeconds(.2f);
         gunfire.SetActive(false); 
     }
     IEnumerator shootWait(){ //-ADDED
        yield return new WaitForSeconds(timeBetweenShots);
         canShoot = true;
     }
     public void reload(){
        StartCoroutine(reloadTimer());
     }
      IEnumerator reloadTimer(){ //-ADDED
        yield return new WaitForSeconds(reloadTime);
         hasAmmo = 10;
         ammoBar.value = hasAmmo;
     }
}
