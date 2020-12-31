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

    private Animator _animator;
    private bool isDistanceCheck = false;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Target = GameObject.Find("Player").GetComponent<Transform>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            VieEnemie -= 10;
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
        float distance = Vector3.Distance(transform.position, Target.position);

        agent.destination = Target.position;
        if (distance <= 3)
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
