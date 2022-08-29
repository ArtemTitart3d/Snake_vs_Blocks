using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public TextMeshPro HPText;
    private int FoodCount;
    [SerializeField] private int _foodCountMin;
    [SerializeField] private int _foodCountMax;
    

    void SetFoodCount()
    {
        FoodCount = Random.Range(_foodCountMin, _foodCountMax + 1);
        HPText.text = FoodCount.ToString();
        
        
    }

    private void Awake()
    {
        SetFoodCount();
    }

}
