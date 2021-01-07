using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public static int scoreValueP1 = 0;
    public static int scoreValueP2 = 0;

    public Text score;
    void Start()
    {
        score = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score : " + scoreValueP1;
    }
}
