using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject cube;
    public Rigidbody cubeV;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")){
                cube.transform.position = new Vector3(player.transform.position.x,100,player.transform.position.z);
                cubeV.velocity = new Vector3(0,-5,0);
        }
    }
}
