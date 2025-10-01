using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        int playerIndexLayer = LayerMask.NameToLayer("Player");

        if (layer == playerIndexLayer)
        {
            print("You've completed the game!");
        }
                
    }

}
