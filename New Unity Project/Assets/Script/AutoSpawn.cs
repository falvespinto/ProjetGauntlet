using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawn : MonoBehaviour
{
    public Transform Player;
    public int DistanceDeSpawn;
    public GameObject PrefabToSpawn;
    public float SpawnRate = 3f;
    public float Distance;
    public int MaxSpawn = 3;
    public bool ReSpawn;

    private float NextSpawn;
    private int Nbr;
    private int Nb;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(transform.position, Player.position);

        if(Distance < DistanceDeSpawn && Nbr<MaxSpawn)
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
}
