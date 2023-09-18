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
}
