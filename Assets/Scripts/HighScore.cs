using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreText;
    float high_score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Score = PlayerController.instance.score;
        if (Score > high_score)
        {
            high_score = Score;
            highScoreText.text = "High Score: " + high_score.ToString();
        }
    }
}
