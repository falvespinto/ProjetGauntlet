using System.Collections;
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
            ScoresPlayer.scoreValueP1 += 50;
        else if (collision.gameObject.tag == "BulletP2" && VieSpawn <= 0)
            ScoresPlayer.scoreValueP2 += 50;
    }




    // Update is called once per frame
    void Update()
    {

        targetOne = GameObject.Find("Player 1").GetComponent<Transform>();
        distancePlayerOne = Vector3.Distance(transform.position, targetOne.position);
        targetTwo = GameObject.Find("Player 2").GetComponent<Transform>();
        distancePlayerTwo = Vector3.Distance(transform.position, targetTwo.position);

        if (distancePlayerOne < DistanceDeSpawn && Nbr<MaxSpawn || distancePlayerTwo < DistanceDeSpawn && Nbr < MaxSpawn)
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

         if(VieSpawn <= 0)
            Destroy(gameObject);

    }



}
