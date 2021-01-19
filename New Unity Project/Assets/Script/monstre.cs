using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class monstre : MonoBehaviour
{
    public Transform Player;
    public Transform targetOne;
    public Transform targetTwo;
    public UnityEngine.AI.NavMeshAgent agent;
    public int VieEnemie = 50;
    private bool Player1isDead;
    private bool Player2isDead;

    public Animator _animator;
    private bool isDistanceCheck = false;
    private float timeLeft = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            VieEnemie -= 10;
        else if (collision.gameObject.tag == "BulletP2")
            VieEnemie -= 10;

        if (collision.gameObject.tag == "Bullet" && VieEnemie <= 0)
            ScoresPlayer.scoreValueP1 += 10;
        else if (collision.gameObject.tag == "BulletP2" && VieEnemie <= 0)
            ScoresPlayer.scoreValueP2 += 10;
    }



    // Update is called once per frame
    void Update()
    {
        if (!Player1isDead)
        {

        }
        targetOne = GameObject.Find("Player 1").GetComponent<Transform>();
        targetTwo = GameObject.Find("Player 2").GetComponent<Transform>();
        float distancePlayerOne = Vector3.Distance(transform.position, targetOne.position);
        float distancePlayerTwo = Vector3.Distance(transform.position, targetTwo.position);

        Debug.Log(targetOne);
        Debug.Log(targetTwo);
        if (distancePlayerOne < distancePlayerTwo)
        {
            Debug.Log("step 1 ok");
            agent.destination = targetOne.position;
        }

        else
        {
            agent.destination = targetTwo.position;
            Debug.Log("step 2 ok");
        }



        
        
        
            //if (GameObject.FindGameObjectsWithTag("Player") != null)
            //{
            //    GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
            //}
        




        if (VieEnemie <= 0)
            Destroy(gameObject);

    }


    
}
