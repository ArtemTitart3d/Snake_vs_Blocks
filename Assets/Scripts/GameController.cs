using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;

        Debug.Log("Dead");
    }
    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
    }
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();

        }

    }
    public int BestScore
    {
        get => PlayerPrefs.GetInt(ScoreIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(ScoreIndexKey, value);
            PlayerPrefs.Save();

        }
    }
    private const string LevelIndexKey = "LevelIndex";
    private const string ScoreIndexKey = "Score";
}
