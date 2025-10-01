using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;

        print("You've completed the game!");
        
        Destroy(collision.gameObject.transform.parent.gameObject);
    }

}
