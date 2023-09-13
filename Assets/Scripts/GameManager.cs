using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // NOTE: 
    // I can control my whole important stuff like player, door, fade, etc. with GameManager. I don't need to connect them each other directly.
    // We need just one game manager in every scene. Idea is move this game manager from level to level

    private void Awake()
    {
        // Keep this GameManager object and prevent destroying it when new scene/level loaded
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }


}
