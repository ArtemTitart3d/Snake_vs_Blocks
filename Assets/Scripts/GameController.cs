using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] private LevelsList _levelsList;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;
    [SerializeField] private GameObject _player;
    private int _currentLevelIndex;
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

    private void Awake()
    {
        _currentLevelIndex = _saveLoadSystem.GetLevelIndex();
        _currentLevelIndex %= _levelsList.Levels.Length;
        var level = Instantiate(_levelsList.Levels[_currentLevelIndex]);
        _player.transform.position = level.GetComponentInChildren<LevelStartPoint>().StartPoint.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextLevel();
        }

    }

    private void LoadNextLevel()
    {
        _currentLevelIndex++;
        _saveLoadSystem.SaveLevel(_currentLevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
