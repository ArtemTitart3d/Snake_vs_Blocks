using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField] private LevelsList _levelsList;
    [SerializeField] private SaveLoadSystem _saveLoadSystem;
    [SerializeField] private GameObject _snake;
    [SerializeField] private ScreenManager Screens;
    [SerializeField] private SnakeMovement Snake;
    public AudioSource _beckgroundMusic;
    public int _currentLevelIndex;
    public float _startLevelPoint;
    public float _endLevelPoint;
    

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
        Screens.Lose();
        _beckgroundMusic.volume = 0.05f;

        Debug.Log("Dead");
    }
    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Screens.Win();
        if (BestScore <= Snake.SnakeScore)
        {
            BestScore = Snake.SnakeScore;
        }
        _beckgroundMusic.volume = 0.05f;


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
        _snake.transform.position = level.GetComponentInChildren<LevelStartPoint>().StartPoint.position;
        _startLevelPoint = _snake.transform.position.z;
        _endLevelPoint = level.GetComponentInChildren<LevelFinishPoint>().FinishPoint.position.z;
        _beckgroundMusic.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextLevel();
        }

    }

    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        _saveLoadSystem.SaveLevel(_currentLevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void RestartLevel()
    {
        ScreenManager.NoMenu = true;
        _saveLoadSystem.SaveLevel(_currentLevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnApplicationQuit()
    {
        ScreenManager.NoMenu = false;
    }
}
