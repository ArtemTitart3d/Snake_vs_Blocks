using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class ScreenManager : MonoBehaviour
    {


        private List<Screen> _screens;
        private Screen _activeScreen;
        [SerializeField] private GameObject _buttonStart;
        [SerializeField] private GameController Game;
        public static bool NoMenu = false;

        private void Start()
        {
            _screens = new List<Screen>();
            _screens.AddRange(GetComponentsInChildren<Screen>());
            _buttonStart = GameObject.Find("StartGameButton");

            foreach (var screen in _screens)
            {

                if (NoMenu)
                {
                    if (screen is MainScreen)
                    {
                        
                        screen.ShowScreen();
                        _activeScreen = screen;

                    }
                    else
                    {
                        
                        screen.HideScreen();

                    }
                }
                else if (screen is StartScreen)
                {
                    screen.ShowScreen();
                    _activeScreen = screen;
                    _buttonStart.GetComponent<Button>().onClick.AddListener(StartGame);
                }
                else
                {
                    screen.HideScreen();
                }
            }
        }

        public void StartGame()
        {
            _activeScreen.HideScreen();

            foreach (var screen in _screens)
            {
                if (screen is MainScreen)
                {
                    screen.ShowScreen();
                    _activeScreen = screen;
                    break;
                }
            }
        }

        public void Win()
        {
            _activeScreen.HideScreen();

            foreach (var screen in _screens)
            {
                if (screen is WinScreen)
                {
                    screen.ShowScreen();
                    _activeScreen = screen;
                    break;
                }
            }
        }

        public void Lose()
        {
            _activeScreen.HideScreen();

            foreach (var screen in _screens)
            {
                if (screen is LoseScreen)
                {
                    screen.ShowScreen();
                    _activeScreen = screen;
                    break;
                }
            }
        }
        

    }
}