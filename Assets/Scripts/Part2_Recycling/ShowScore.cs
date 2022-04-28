using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text scoreText;
    private int scorenum;

    void Start()
    {
        
    }

    void Update()
    {
        scorenum = GameManager.score;
        scoreText.text = GameManager.score.ToString();
    }
}
