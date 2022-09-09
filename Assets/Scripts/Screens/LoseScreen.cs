using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class LoseScreen : Screen
    {
        [SerializeField] private GameObject[] _objects;
        [SerializeField] private Text ScoreText;
        [SerializeField] private Text BestScoreText;
        [SerializeField] private SnakeMovement Snake;
        [SerializeField] private GameController Game;
        public override void ShowScreen()
        {
            foreach (var obj in _objects)
            {
                obj.SetActive(true);
            }
            ScoreText.text = "Your score: " + Snake.SnakeScore.ToString();
            if (Snake.SnakeScore >= Game.BestScore)
            {
                BestScoreText.text = "New record: " + Snake.SnakeScore.ToString();
            }
            else BestScoreText.text = "Your old record: " + Game.BestScore.ToString();
        }

        public override void HideScreen()
        {

            foreach (var obj in _objects)
            {
                obj.SetActive(false);
            }
        }
    }
}