using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameManager : MonoBehaviour
{
    [SerializeField] float restartDelay = 2f;
    [SerializeField] TextMeshProUGUI gameText;
    [SerializeField] TextMeshProUGUI scoreText;
    private void Start()
    {
        UpdateGameText("Good luck!");
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
    public void UpdateGameText(string text)
    {
        if (gameText != null)
        {
            gameText.text = text;
        }
    }
    public void RestartScene() => Invoke(nameof(LoadScene), restartDelay);
    private void LoadScene() => SceneManager.LoadScene(0);
    private void Awake() => DontDestroyOnLoad(gameObject);

}
