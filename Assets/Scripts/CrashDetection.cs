using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class CrashDetection : MonoBehaviour
{
    private PlayerController playerController;
    private GameManager gameManager;


    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        gameManager = GetComponent<GameManager>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        Debug.Log($"Collided with {collision.gameObject.name} - {layer}");

        playerController.DisableControls();
        gameManager.RestartScene();
    }
}
