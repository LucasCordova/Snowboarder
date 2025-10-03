using UnityEngine;

public class CrashDetection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        int playerIndexLayer = LayerMask.NameToLayer("PlayerLayer");


        if (layer == playerIndexLayer)
        {
            print("You've crashed buddy");
            
        }
    }
}
