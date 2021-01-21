using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mort : MonoBehaviour
{

    private bool Player1isDead = false;
    private bool Player2isDead = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player 1") == null)
        {
            Player1isDead = true;
            Debug.Log("MORT");
            if (Player1isDead == true && SceneManager.GetActiveScene().name == "GameSolo")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            }
        }
        if (GameObject.Find("Player 2") == null)
        {
            Player2isDead = true;
            if (Player2isDead == true && Player1isDead == true && SceneManager.GetActiveScene().name == "GameCoop" )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }

        }
    }
}
