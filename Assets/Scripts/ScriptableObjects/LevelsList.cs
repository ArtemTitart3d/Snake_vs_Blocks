using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelsList", menuName = "MyMenu/LevelsList", order = 0)]
    public class LevelsList : ScriptableObject
    {
        public GameObject[] Levels;
    }
}