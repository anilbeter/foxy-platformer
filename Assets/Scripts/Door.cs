using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int lvlToLoad;

    public Sprite unlockedSprite;
    private BoxCollider2D boxCol;


    void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // To ensure dont call load level function multiple times, I disable it
            boxCol.enabled = false;
            // also I want to disable player controls
            collision.GetComponent<GatherInput>().DisableControls();

            GameManager.ManagerLoadLevel(lvlToLoad);
        }
    }

    public void UnlockDoor()
    {
        GetComponent<SpriteRenderer>().sprite = unlockedSprite;
        boxCol.enabled = true;
    }
}
