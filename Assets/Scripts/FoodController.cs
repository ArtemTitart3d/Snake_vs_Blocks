using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public TextMeshPro HPText;
    [HideInInspector] public int FoodCount;
    [SerializeField] private int _foodCountMin;
    [SerializeField] private int _foodCountMax;
    [SerializeField] private GameObject _food;
    


    void SetFoodCount()
    {
        FoodCount = Random.Range(_foodCountMin, _foodCountMax + 1);
        HPText.text = FoodCount.ToString();
        
        
    }
  

    private void Awake()
    {
         SetFoodCount();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SnakeMovement Snake))
        {
            Snake.GrowLenght(FoodCount);
            Snake.ScoreThePlayer(FoodCount);
            Destroy(HPText);
            Destroy(_food);
            
        }
        
    }
}
