using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    [SerializeField] ParticleSystem finishLineParticleSystem;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        int playerIndexLayer = LayerMask.NameToLayer("PlayerLayer");

        if (layer == playerIndexLayer)
        {
            print("You've completed the game!");
            finishLineParticleSystem.Play();
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        int playerIndexLayer = LayerMask.NameToLayer("PlayerLayer");

        if (layer == playerIndexLayer)
        {
            finishLineParticleSystem.Stop();
            Invoke("RestartDelay", delayInSeconds);
        }
    }

    void RestartDelay()
    {
        SceneManager.LoadScene(0);
    }

}
