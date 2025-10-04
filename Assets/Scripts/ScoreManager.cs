using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI scoreText;


    private int score = 0;

    void Awake()
    { 
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        scoreText.text = "Good luck!";
    }

    public void AddScore(int additionalScore)
    {
        score += additionalScore;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

}
