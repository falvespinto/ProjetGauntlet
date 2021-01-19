using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Translation & Rotation")]
    [SerializeField] float m_TranslatationSpeed;

    [Tooltip("Rotation speed in */s")]
    [SerializeField] float m_RotSpeed;

    
    private CharacterController Player;
    public int Sensi;
    public int gravite = 20;
    public int ViePlayer = 100;
    public float moveSpeed;
    

    private Vector3 DirectionDeplacement = Vector3.zero;
    private Rigidbody myRigidbody;
    private Vector3 moveVelocity;
    private Camera mainCamera;




    Transform m_Transform;

    

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }


    void Start()
    {
        Player = GetComponent<CharacterController>();
        mainCamera = FindObjectOfType<Camera>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monstre")
            ViePlayer -= 10;



    }



    // Update is called once per frame
    void Update()
    {
        //déplacement
        DirectionDeplacement.z = Input.GetAxisRaw("Vertical");
        DirectionDeplacement.x = Input.GetAxisRaw("Horizontal");
        //DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);
        Player.Move(DirectionDeplacement * m_TranslatationSpeed * Time.deltaTime);


        transform.Rotate(0, Input.GetAxisRaw("Mouse X")*Sensi, 0);

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(pointToLook);
        }

        

        //Gravité
        if(!Player.isGrounded)
        {
            DirectionDeplacement.y -= gravite * Time.deltaTime;
        }
    
        if (ViePlayer <= 0)
            Destroy(gameObject);

    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
}
