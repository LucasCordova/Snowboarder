using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        int playerIndexLayer = LayerMask.NameToLayer("PlayerLayer");

        if (layer == playerIndexLayer)
        {
            print("You've completed the game!");
            SceneManager.LoadScene(0);
        }
                
    }

}
