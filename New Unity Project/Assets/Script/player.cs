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

    Transform m_Transform;

    Rigidbody m_RigidBody;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        m_RigidBody = GetComponent<Rigidbody>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float mouveHorizontal = Input.GetAxis("Horizontal");
        float mouveVertical = Input.GetAxis("Vertical");

        Vector3 mouvment = new Vector3(mouveHorizontal, 0, mouveVertical);
        m_RigidBody.AddForce(mouvment * m_TranslatationSpeed * Time.deltaTime);
        float rotAngle = mouveHorizontal * m_RotSpeed * Time.fixedDeltaTime;

    }
}
