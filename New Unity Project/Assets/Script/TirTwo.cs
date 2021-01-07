using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirTwo : MonoBehaviour
{
    public GameObject Projectile;
    public int Force = 50;
    public AudioClip SoundTir;
    public GameObject PointTire;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("TireManette"))
        {
            GetComponent<AudioSource>().PlayOneShot(SoundTir);
            GameObject BulletP2 = Instantiate(Projectile, transform.position, transform.rotation) as GameObject;
            BulletP2.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * Force;
            Destroy(BulletP2, 2f);

        }
    }

}

