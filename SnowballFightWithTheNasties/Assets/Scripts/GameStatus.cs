using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // configurations
    [Range(0.1f, 10.0f)] [SerializeField] float gameSpeed = 0.70f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;

    // state variables
    [SerializeField] int currentScore = 0;

    private void Start()
    {
        
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void addToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

}
