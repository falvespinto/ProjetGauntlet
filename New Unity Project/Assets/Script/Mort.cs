using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetourMenuMort : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public bool soloMode = true;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (soloMode)
            ResetSoloMode();
        else
            ResetCoopMode();
        
    }

    void ResetSoloMode()
    {
        if (player1 == null)
        {
            SceneManager.LoadScene(0);
        }
    }

    void ResetCoopMode()
    {
        if (player1 == null && player2 == null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
