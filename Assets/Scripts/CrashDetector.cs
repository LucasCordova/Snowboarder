using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("SnowLayer");
        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("You crashed!");
        }
    }
}
