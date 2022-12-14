using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    private SnakeMovement SnakeMovement;

    private void Awake()
    {
        positions.Add(SnakeHead.position);
        SnakeMovement = GetComponent<SnakeMovement>();
    }

    private void Update()
    {
        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            // Направление от старого положения головы, к новому
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        Destroy(snakeCircles[SnakeMovement.Length].gameObject);
        snakeCircles.RemoveAt(SnakeMovement.Length);
        positions.RemoveAt(SnakeMovement.Length + 1);
        
    }
}
