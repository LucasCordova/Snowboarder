using UnityEngine;

public class PowerManager : MonoBehaviour
{
    [SerializeField] private PowerupScriptable powerup;
    private PlayerController player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player collided with us, then activate the power up
        int layerIndex = LayerMask.NameToLayer("PlayerLayer");
        if (collision.gameObject.layer == layerIndex)
        {
            // Activate PowerUp
            player.ActivatePowerup(powerup);
        }
    }

}
