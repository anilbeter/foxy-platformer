using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // NOTE: 
    // I can control my whole important stuff like player, door, fade, etc. with GameManager. I don't need to connect them each other directly.
    // We need just one game manager in every scene. Idea is move this game manager from level to level

    // static means -> we save this instance in the memory and it will stay there until we exit the game
    // also I can easily access to this class in other script, I don't need to find game manager object and getcomponent stuff. Because it's just have static keyword
    private static GameManager GM;

    private void Awake()
    {
        if (GM == null)
        {
            // this means -> this whole GameManager script
            GM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // Idea -> REMEMBER: there's must only one game manager on each level. Player just started the game and there's not GM atm, so if condition will work (line 20 and 21). Then player arrived to level 2, oh no, there's two game manager object one of them from level 1 (cuz' in the if statement we use DontDestroyOnLoad), so now we have 2 game manager object in level 2 / scene 2. Now else statement works and Destroy previous one, again we have just 1 game manager, as it should be

    }

    void Start()
    {

    }


}
