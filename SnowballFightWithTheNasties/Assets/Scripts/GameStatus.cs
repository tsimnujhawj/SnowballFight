using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // configurations
    [Range(0.1f, 10.0f)] [SerializeField] float gameSpeed = 0.70f;
    [SerializeField] int pointsPerBlockDestroyed = 10;

    // state variables
    [SerializeField] int currentScore = 0;

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void addToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

}
