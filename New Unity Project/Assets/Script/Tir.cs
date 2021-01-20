﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject Projectile;
    public int Force = 50;
    public AudioClip SoundTir;
    public GameObject PointTire;
    public float FireRate;
    private float NextFire;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > NextFire && Time.timeScale!=0)
        {
            GetComponent<AudioSource>().PlayOneShot(SoundTir);
            GameObject Bullet = Instantiate(Projectile, transform.position, transform.rotation) as GameObject;
            Bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * Force;
            Destroy(Bullet, 4f);

            NextFire = Time.time + FireRate;


        }
    }

}
