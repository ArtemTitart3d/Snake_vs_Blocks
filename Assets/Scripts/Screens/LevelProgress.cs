using Assets.Scripts.ScriptableObjects;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private SnakeMovement Snake;
    [SerializeField] private GameController Game;
    [SerializeField] private Slider Slider;
    
    private float _startZ;
    private float _endZ;
    private float _snakePosition;
    

    private void Start()
    {
         _startZ = Game._startLevelPoint;
        _endZ = Game._endLevelPoint;
    }
    private void Update()
    {
        
        _snakePosition = Snake.transform.position.z;
        float t = Mathf.InverseLerp(_startZ, _endZ, _snakePosition);
        Slider.value = t;
        

    }
}
