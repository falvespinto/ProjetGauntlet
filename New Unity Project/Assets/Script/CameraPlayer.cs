using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPlayer : MonoBehaviour
{
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;

    private bool Player1isDead = false;
    private bool Player2isDead = false;

    private Vector3 cameraPosition;
    private Vector3 smoothPosition;

    Vector3 offsetCamera;

    [Range(0.01f, 1.0f)]
    [SerializeField]
    float smooth;

    // Start is called before the first frame update
    void Start()
    {
        offsetCamera = transform.position - target1.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //cameraPosition = target1.position + offsetCamera;
        //smoothPosition = Vector3.Lerp(transform.position, cameraPosition,smooth);
        //transform.position = smoothPosition;

        if (GameObject.Find("Player 1") != null && Player1isDead == false)
        {

            target1 = GameObject.Find("Player 1").GetComponent<Transform>();
            cameraPosition = target1.position + offsetCamera;
            smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smooth);
            transform.position = smoothPosition;

        }
        else 
        { 
            Player1isDead = true;
            target2 = GameObject.Find("Player 2").GetComponent<Transform>();
            cameraPosition = target2.position + offsetCamera;
            smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smooth);
            transform.position = smoothPosition;

        }


    }
}
