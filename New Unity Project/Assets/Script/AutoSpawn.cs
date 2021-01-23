﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawn : MonoBehaviour
{
    //public Transform Player;
    public int DistanceDeSpawn;
    public int VieSpawn = 80;
    public GameObject PrefabToSpawn;
    public float SpawnRate = 3f;
    private Transform targetOne;
    private Transform targetTwo;
    public int MaxSpawn = 3;
    public bool ReSpawn;

    private float distancePlayerOne;
    private float distancePlayerTwo;
    private float NextSpawn;
    private int Nbr;
    private int Nb;

    private bool Player1isDead = false;
    private bool Player2isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            VieSpawn -= 20;
        else if (collision.gameObject.tag == "BulletP2")
            VieSpawn -= 10;

        if (collision.gameObject.tag == "Bullet" && VieSpawn <= 0)
            ScoreScript.scoreValue += 50;
        else if (collision.gameObject.tag == "BulletP2" && VieSpawn <= 0)
            ScoreScript.scoreValue += 50;
    }

    private void godMod()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        godMod();

        if (GameObject.Find("Player 1") != null && Player1isDead == false)
        {
            Debug.Log("step 1");
            targetOne = GameObject.Find("Player 1").GetComponent<Transform>();
            distancePlayerOne = Vector3.Distance(transform.position, targetOne.position);
        }
        else { Player1isDead = true; }
        if (GameObject.Find("Player 2") != null && Player2isDead == false)
        {
            Debug.Log("step 2");
            targetTwo = GameObject.Find("Player 2").GetComponent<Transform>();
            distancePlayerTwo = Vector3.Distance(transform.position, targetTwo.position);
        }
        else { Player2isDead = true; }


        if (!Player1isDead && !Player2isDead)
        {

            if (distancePlayerOne < DistanceDeSpawn && Nbr < MaxSpawn || distancePlayerTwo < DistanceDeSpawn && Nbr < MaxSpawn)
            {
                if (Time.time > NextSpawn)
                {
                    NextSpawn = Time.time + SpawnRate;
                    GameObject GO = Instantiate(PrefabToSpawn, transform.position, Quaternion.identity) as GameObject;
                    GO.name = "Enemie " + this.name;
                    Nbr++;
                }
            }
            if (ReSpawn)
            {
                Nb = 0;

                foreach (GameObject Enn in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (Enn.name == "Enemie " + this.name)
                        Nb++;
                }

                if (Nb < MaxSpawn)
                    Nbr = Nb;
            }
        }
        if (Player1isDead && !Player2isDead)
        {

            if (distancePlayerTwo < DistanceDeSpawn && Nbr < MaxSpawn)
            {
                if (Time.time > NextSpawn)
                {
                    NextSpawn = Time.time + SpawnRate;
                    GameObject GO = Instantiate(PrefabToSpawn, transform.position, Quaternion.identity) as GameObject;
                    GO.name = "Enemie " + this.name;
                    Nbr++;
                }
            }
            if (ReSpawn)
            {
                Nb = 0;

                foreach (GameObject Enn in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (Enn.name == "Enemie " + this.name)
                        Nb++;
                }

                if (Nb < MaxSpawn)
                    Nbr = Nb;
            }

        }

        if (Player2isDead && !Player1isDead)
        {


            if (distancePlayerOne < DistanceDeSpawn && Nbr < MaxSpawn)
            {
                if (Time.time > NextSpawn)
                {
                    NextSpawn = Time.time + SpawnRate;
                    GameObject GO = Instantiate(PrefabToSpawn, transform.position, Quaternion.identity) as GameObject;
                    GO.name = "Enemie " + this.name;
                    Nbr++;
                }
            }
            if (ReSpawn)
            {
                Nb = 0;

                foreach (GameObject Enn in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (Enn.name == "Enemie " + this.name)
                        Nb++;
                }

                if (Nb < MaxSpawn)
                    Nbr = Nb;
            }

        }

        if (VieSpawn <= 0)
            Destroy(gameObject);


    }



}
