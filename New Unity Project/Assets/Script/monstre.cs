using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class monstre : MonoBehaviour
{
    public Transform targetOne;
    public Transform targetTwo;
    public UnityEngine.AI.NavMeshAgent agent;
    public int VieEnemie = 50;

    private Animator _animator;
    private bool isDistanceCheck = false;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        targetOne = GameObject.Find("Player 1").GetComponent<Transform>();
        targetTwo = GameObject.Find("Player 2").GetComponent<Transform>();

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
        Attack();

        if (VieEnemie <= 0)
            Destroy(gameObject);

    }

    public void Attack()
    {
        float distancePlayerOne = Vector3.Distance(transform.position, targetOne.position);
        float distancePlayerTwo = Vector3.Distance(transform.position, targetTwo.position);

        if (distancePlayerOne < distancePlayerTwo)
            agent.destination = targetOne.position;
        else
            agent.destination = targetTwo.position;




        if (distancePlayerOne <= 3)
        {
            if (!isDistanceCheck)
                isDistanceCheck = true;
            if (isDistanceCheck == true)
            {
                //attack
                _animator.SetBool("Attack", true);
            }
            else
            {
                _animator.SetBool("Attack", false);
                isDistanceCheck = false;

            }
        }
    }
}
