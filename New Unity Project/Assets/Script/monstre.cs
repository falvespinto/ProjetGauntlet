using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monstre : MonoBehaviour
{
    public Transform Target;
    public UnityEngine.AI.NavMeshAgent agent;
    public int VieEnemie = 50; 

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            VieEnemie -= 10;
        }
    }



    // Update is called once per frame
    void Update()
    {
        agent.destination = Target.position;
        if (VieEnemie <= 0)
            Destroy(gameObject);
    }
}
