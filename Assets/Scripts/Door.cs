using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int lvlToLoad;


    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // To ensure dont call load level function multiple times, I disable it
            GetComponent<BoxCollider2D>().enabled = false;
            // also I want to disable player controls
            collision.GetComponent<GatherInput>().DisableControls();

            GameManager.ManagerLoadLevel(lvlToLoad);
        }
    }
}
