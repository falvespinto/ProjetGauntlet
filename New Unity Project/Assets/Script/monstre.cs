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
    public int VieEnemie = 40;
    private bool Player1isDead = false;
    private bool Player2isDead = false;

    public Animator _animator;
    private bool isDistanceCheck = false;
    private float timeLeft = 1.0f;


    private float distancePlayerOne;
    private float distancePlayerTwo;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            VieEnemie -= 20;
        else if (collision.gameObject.tag == "BulletP2")
            VieEnemie -= 10;

        if (collision.gameObject.tag == "Bullet" && VieEnemie <= 0)
            ScoresPlayer.scoreValueP1 += 10;
        else if (collision.gameObject.tag == "BulletP2" && VieEnemie <= 0)
            ScoresPlayer.scoreValueP2 += 10;

        if (collision.gameObject.tag == "Player")
        {
            _animator.Play("MonstreAttaqueBool");
        }
  
    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log(distancePlayerOne);

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
            targetTwo= GameObject.Find("Player 2").GetComponent<Transform>();
            distancePlayerTwo = Vector3.Distance(transform.position, targetTwo.position);
        }
        else { Player2isDead = true; }

        if (!Player1isDead && !Player2isDead)
        {
            Debug.Log("PlayerOne : " + Player1isDead);
            Debug.Log("PlayerTwo : " + Player2isDead);

            if (distancePlayerOne < distancePlayerTwo)
            {
                agent.destination = targetOne.position;

            }
            else
            {
                agent.destination = targetTwo.position;

            }
        }
        if (Player1isDead && !Player2isDead)
        {
            agent.destination = targetTwo.position;
        }

        if (Player2isDead && !Player1isDead)
        {
            agent.destination = targetOne.position;
        }

        




        //if (GameObject.FindGameObjectsWithTag("Player") != null)
        //{
        //    GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Transform>();
        //}





        if (VieEnemie <= 0)
            Destroy(gameObject);

    }


    
}
