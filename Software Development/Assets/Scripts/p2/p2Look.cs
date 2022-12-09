using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Look : MonoBehaviour
{

      
    public Transform playerBody;
    public GameObject player;
    public static int sensitivity = 1;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
         float mouseX = ((Input.GetAxis("ControllerLookX"))*sensitivity * Time.deltaTime  );
            float mouseY = ((Input.GetAxis("ControllerLookY")) *sensitivity * Time.deltaTime ) ;

           xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

           playerBody.Rotate(Vector3.up * mouseX);




    }
}
