using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;

    // cached reference
    Level level;
    GameSession gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        gameObject.SetActive(false);
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
