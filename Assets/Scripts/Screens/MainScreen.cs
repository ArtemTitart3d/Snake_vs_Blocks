using UnityEngine;

namespace Screens
{
    public class MainScreen : Screen
    {
        [SerializeField] private GameObject[] _objects;
        public override void ShowScreen()
        {
            foreach (var obj in _objects)
            {
                obj.SetActive(true);
            }
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