using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float baseSpeed = 20f;
    [SerializeField] private float boostSpeed = 30f;
    private InputAction moveAction;
    private Rigidbody2D playerRigidbody;
    private SurfaceEffector2D surfaceEffector2D;
    private GameManager gameManager;
    private int score = 0;
    private bool canMove = true;
    private float previousRotation = 0f;
    private float totalRotation = 0f;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        playerRigidbody = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void Update()
    {
        if (!canMove) return;

        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        RotatePlayer(moveVector);
        BoostPlayer(moveVector);
        CalculateFlips();
    }

    private void BoostPlayer(Vector2 moveVector)
    {
        if (moveVector.y > 0f) surfaceEffector2D.speed = boostSpeed;
        else surfaceEffector2D.speed = baseSpeed;
    }

    private void RotatePlayer(Vector2 moveVector)
    {
        if (moveVector.x > 0f) playerRigidbody.AddTorque(-torqueAmount);
        else if (moveVector.x < 0f) playerRigidbody.AddTorque(torqueAmount);
    }

    private void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if (totalRotation > 340 || totalRotation < -340)
        {
            totalRotation = 0;
            gameManager.UpdateGameText("Nice flip! +100 points");
            gameManager.UpdateScore(score += 100);
        }
        previousRotation = currentRotation;
    }

    public void DisableControls() => canMove = false;
}