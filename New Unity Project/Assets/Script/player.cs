using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Translation & Rotation")]
    [SerializeField] float m_TranslatationSpeed;

    [Tooltip("Rotation speed in */s")]
    [SerializeField] float m_RotSpeed;

    private Vector3 DirectionDeplacement = Vector3.zero;
    private CharacterController Player;
    public int Sensi;
    public int gravite = 20;

    public int ViePlayer = 100;

    Transform m_Transform;



    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }


    void Start()
    {
        Player = GetComponent<CharacterController>();  
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
        DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);
        Player.Move(DirectionDeplacement * m_TranslatationSpeed * Time.deltaTime);

        transform.Rotate(0, Input.GetAxisRaw("Mouse X")*Sensi, 0);

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

    }
}
