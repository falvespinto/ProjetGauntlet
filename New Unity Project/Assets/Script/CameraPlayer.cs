using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraPlayer : MonoBehaviour
{
    [SerializeField] GameObject target1;
    [SerializeField] GameObject target2;

    private bool Player1isDead = false;

    private Vector3 cameraPosition;
    private Vector3 smoothPosition;

    public Vector3 offsetCamera;

    [Range(0.01f, 1.0f)]
    [SerializeField]
    float smooth;

    // Start is called before the first frame update
    void Start()
    {
      // offsetCamera = transform.position - target1.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target1 != null && Player1isDead == false)
        {
            cameraPosition = target1.transform.position + offsetCamera;
            smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smooth);
            transform.position = smoothPosition;

        }
        else 
        { 
            cameraPosition = target2.transform.position + offsetCamera;
            smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smooth);
            transform.position = smoothPosition;
        }


    }
}
