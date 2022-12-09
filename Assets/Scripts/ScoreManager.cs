using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Text scoreText;
    int score = 0;
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void addPoints(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public int getPoints()
    {
        return score;
    }

}
