using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class monstre : MonoBehaviour
{
    public Transform Target;
    public UnityEngine.AI.NavMeshAgent agent;
    public int VieEnemie = 50;

    private Animation animator;
    private bool isDistanceCheck = false;
    private float timeLeft = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animation>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Target = GameObject.Find("Player").GetComponent<Transform>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
            VieEnemie -= 10;
    }



    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Target.position);

        agent.destination = Target.position;
        if (distance <= 3)
        {
            if (!isDistanceCheck)
                isDistanceCheck = true;
            else
                timeLeft -= Time.deltaTime;
            if(timeLeft <= 0.0f)
            {
                //attack
               // animator.SetBool("Attack", true);
            }
            
        }

        if (VieEnemie <= 0)
            Destroy(gameObject);


    }
}
