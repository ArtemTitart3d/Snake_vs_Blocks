using UnityEngine;

namespace Screens
{
    public abstract class Screen : MonoBehaviour
    {
        public abstract void ShowScreen();
        public abstract void HideScreen();
    }
}