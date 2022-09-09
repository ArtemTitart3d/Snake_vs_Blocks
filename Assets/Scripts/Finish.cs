using Screens;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeMovement Snake))
        {
            Snake.Win();

        }
        

    }
}
