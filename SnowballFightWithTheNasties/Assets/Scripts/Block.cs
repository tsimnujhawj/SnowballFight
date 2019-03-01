using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [Range(0f, 10f)] [SerializeField] float destroyAfterTime = 1f;
    [Range(0, 10)] [SerializeField] int maxHits;

    // cached reference
    Level level;
    GameSession gameStatus;

    // state variables
    [SerializeField] int timesHit; // TODO: only serialized for debugging

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        TriggerSparklesVFX();
        PlayBlockDestorySFX();
        gameStatus.AddToScore();
        gameObject.SetActive(false);
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void PlayBlockDestorySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, destroyAfterTime);
    }
}
