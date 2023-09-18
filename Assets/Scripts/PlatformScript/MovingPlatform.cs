using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
  public float speed;
  public Transform[] points;
  public int startingPoint;

  private int i;

  void Start()
  {
    transform.position = points[startingPoint].position;
  }


  void Update()
  {
    if (UnityEngine.Vector2.Distance(transform.position, points[i].position) < 0.02f)
    {
      i++;
      if (i == points.Length)
      {
        i = 0;
      }
    }

    transform.position = UnityEngine.Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.collider.CompareTag("Player"))
    {
      collision.transform.SetParent(transform);
      // When player and platorm collides, platform object will be parent of the Player 
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.collider.CompareTag("Player"))
    {
      collision.transform.SetParent(null);
      // When player leaves platform, platform object will no longer be parent
    }
  }
}
