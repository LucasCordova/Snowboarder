
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    InputAction moveAction;
    Rigidbody2D rigidbody2D;

    private SurfaceEffector2D surfaceEffector2D;

    private ScoreManager scoreManager;


    private bool canMove = true;

    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;

    private float previousRotation = 0f;
    private float totalRotation = 0f;
    private int flipCount = 0;

    public void CalculateFlips()
    {
        float currentRotation = transform.rotation.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        previousRotation = currentRotation;
        if (totalRotation >= 360f)
        {
            flipCount++;
            scoreManager.AddScore(100);
            totalRotation = 0f;
        }

        Debug.Log($"Flips: {flipCount}");
    }
    void Update()
    { // Refactored

        if (!canMove) return;

        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        RotatePlayer(moveVector);
        BoostPlayer(moveVector);
        CalculateFlips();
        
    }

    public void DisableControls() => canMove = false;

    void BoostPlayer(Vector2 moveVector)
    {
        if (moveVector.y > 0f) surfaceEffector2D.speed = boostSpeed;
        else surfaceEffector2D.speed = baseSpeed;
    }

    void RotatePlayer(Vector2 moveVector)
    {
        if (moveVector.x > 0f) rigidbody2D.AddTorque(-torqueAmount);
        else if (moveVector.x < 0f) rigidbody2D.AddTorque(torqueAmount);
    }


    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = new ScoreManager();
    }
}