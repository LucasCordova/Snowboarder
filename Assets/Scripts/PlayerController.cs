
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    InputAction moveAction;
    Rigidbody2D rigidbody2D;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x > 0f)
        {
            rigidbody2D.AddTorque(-torqueAmount);
        }
        else if (moveVector.x < 0f)
        {
            rigidbody2D.AddTorque(torqueAmount);
        }
    }
}