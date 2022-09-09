using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private Text CurrentLevel;
    [SerializeField] private Text NextLevel;
    [SerializeField] private GameController Game;
    [SerializeField] private Text Bestscore;
    void Start()
    {
        CurrentLevel.text = (Game._currentLevelIndex + 1).ToString();
        NextLevel.text = (Game._currentLevelIndex + 2).ToString();
        Bestscore.text = "Best Score: " + (Game.BestScore).ToString();
    }

}
