using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeMovement : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float Sensitivity = 10;
    public int Length = 1;
    private bool isDead = false;

    public TextMeshPro PointsText;

    private Camera mainCamera;
    private Rigidbody componentRigidbody;
    private SnakeTail componentSnakeTail;
    [SerializeField] GameController Game;
    

    private Vector3 touchLastPos;
    private float sidewaysSpeed;


   
    private void Start()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody>();
        componentSnakeTail = GetComponent<SnakeTail>();
        
        for (int i = 0; i < Length; i++) componentSnakeTail.AddCircle();

        PointsText.SetText(Length.ToString());
    }

    private void Update()
    {
        //if (Length > 0)
            if (Input.GetMouseButtonDown(0))
              {
                 touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
              }
             else if (Input.GetMouseButtonUp(0))
              {
                  sidewaysSpeed = 0;
              }
             else if (Input.GetMouseButton(0))
             {
            Vector3 delta = mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * Sensitivity;
            componentRigidbody.velocity = new Vector3(sidewaysSpeed * 5, 0, ForwardSpeed);
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
           
             }
       
       

    }

    private void FixedUpdate()
    {
       sidewaysSpeed = 0;
    }

    public void GrowLenght(int FoodCount)
    {
        Length += FoodCount;
        for (int i = 0; i < FoodCount; i++)
        {
            componentSnakeTail.AddCircle();
        }
        
        PointsText.SetText(Length.ToString());
    }
    public void ReduceLenght(int BlockCount)
    {
        
            Length -= BlockCount;
            for (int i = 0; i < BlockCount; i++)
            {
                componentSnakeTail.RemoveCircle();
            }
            PointsText.SetText(Length.ToString());
        
        
    }
    public void Die()
    {
        int LengthBeforDie = Length-1;
        Length = 1;
        PointsText.SetText("X");
        for (int i = 0; i < LengthBeforDie; i++)
        {
            componentSnakeTail.RemoveCircle();
        }
        isDead = true;
        Game.OnPlayerDied();
        
    }
}
