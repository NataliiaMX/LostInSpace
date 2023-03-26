using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float scoreMultiplier;
    private float score;
    private bool shouldCount = true;

    private void Update() 
    {
        if(!shouldCount) { return; }
        CountScore();
    }

    private void CountScore()
    {
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public float EndScoreCounter()
    {
        shouldCount = false;
        scoreText.text = string.Empty;
        return score;
    }

    internal void StartScoreCounter()
    {
        shouldCount = true;
    }
}
