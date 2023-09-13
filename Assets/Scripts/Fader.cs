using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private Animator anim;
    private int lvlToLoad;

    void Start()
    {
        anim = GetComponent<Animator>();

        // we have static instance and functions from GameManager, we have easy access and we don't need to find GameManager object.
        GameManager.RegisterFader(this);
        // Fader is now registered and GameManager can use it
    }

    public void SetLevel(int lvl)
    {
        lvlToLoad = lvl;
        anim.SetTrigger("Fade");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(lvlToLoad);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel()
    {
        Invoke(nameof(Restart), 1.5f);
        // Invokes the method methodName in time seconds. So I write Restart() functions name inside of Invoke, same scene will loaded after 1.5 seconds later
    }
}
