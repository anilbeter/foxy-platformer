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

    private Fader fader;
    private Door theDoor;

    // [WHY list?] I could use array also for the gems, but total gems not the same for each level. I need to define array lenght, but as I say gems number not same, so list is more dynamic and useful in our case.
    private List<Gem> gems;

    private void Awake()
    {
        if (GM == null)
        {
            // this means -> this whole GameManager object
            GM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // Idea -> REMEMBER: there's must only one game manager on each level. Player just started the game and there's not GM atm, so if condition will work (line 20 and 21). Then player arrived to level 2, oh no, there's two game manager object one of them from level 1 (cuz' in the if statement we use DontDestroyOnLoad), so now we have 2 game manager object in level 2 / scene 2. Now else statement works and Destroy previous one, again we have just 1 game manager, as it should be

        gems = new List<Gem>();

    }

    void Start()
    {

    }

    // we can create static functions that will enable objects to register themselves to the GameManager
    public static void RegisterFader(Fader fD)
    {
        if (GM == null)
            return;

        GM.fader = fD;
    }

    public static void RegisterDoor(Door door)
    {
        if (GM == null)
            return;

        GM.theDoor = door;
    }

    public static void ManagerLoadLevel(int index)
    {
        if (GM == null)
            return;

        GM.fader.SetLevel(index);
    }

    public static void ManagerRestartLevel()
    {
        if (GM == null)
            return;

        GM.fader.RestartLevel();
    }

    public static void RegisterGem(Gem gem)
    {
        if (GM == null)
            return;

        // if the list doesn't contain the gem, than add it
        if (!GM.gems.Contains(gem))
            GM.gems.Add(gem);
    }
}
