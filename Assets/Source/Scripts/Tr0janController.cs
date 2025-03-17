using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tr0janController : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] private float moveSpeed = 2f;
    private int pointsIndex = 0;

    void Start()
    {
        transform.position = points[pointsIndex].position;
    }

    void Update()
    {
        if (pointsIndex < points.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[pointsIndex].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, points[pointsIndex].position) < 0.1f)
            {
                pointsIndex++;
            }
        }
    }
}