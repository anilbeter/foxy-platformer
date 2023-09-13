using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.RegisterGem(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // NOTE: Is collision touching/triggering the player? In this situation collision is Gem, because this script attached to the Gem object 
        if (collision.CompareTag("Player"))
        {
            // gameObject -> Gem
            // Destroy(gameObject);

            // [ALTERNATIVE WAY] Destroying game object may be problem in the future for implement sounds, so better way:
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            // In real world project, you should assign GetComponent in Start or Awake functions. I just quickly get them without storing, this is more expansive PC performance but whatever its just 2d platformer and I won't publish it on steam, so anyway

            // Now if player collect all gems in the scene, then door will unlocked
            GameManager.RemoveGemFromList(this);

            GetComponent<AudioSource>().Play();

            collision.GetComponent<PlayerCollectibles>().GemCollected();
        }
    }
}
