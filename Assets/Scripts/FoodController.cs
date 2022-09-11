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
    float _time = 0;
    [SerializeField] float _amp = 0.25f;
    [SerializeField] float _freq =2;
    float _offset = 0;
    Vector3 _startPosition;
   




    void SetFoodCount()
    {
        FoodCount = Random.Range(_foodCountMin, _foodCountMax + 1);
        HPText.text = FoodCount.ToString();
        
        
    }
  

    private void Awake()
    {
         SetFoodCount();
        _startPosition = transform.position;
        
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
    private void Update()
    {
        if (_food != null)
        {
            _food.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
            _time += Time.deltaTime;
            _offset = _amp * Mathf.Sin(_time * _freq);
            transform.position = _startPosition + new Vector3(0, _offset, 0);

        }
        
       
        
    }

}
