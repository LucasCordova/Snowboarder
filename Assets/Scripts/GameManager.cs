using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float restartDelay = 2f;

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartScene()
    {
        Invoke(nameof(LoadScene), restartDelay);
    }

}
