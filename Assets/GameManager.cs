using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text ScoreText;
    public TMP_Text BestScoreText;

    private int _scoreCount = 0;
    private int _bestScore = 0;

    private void Awake()
    {
        // Si jamais on charge une 2e scene
        // avec un autre GameManager
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreText();
        UpdateScoreText();
    }

    public void AddScore(int amount = 1)
    {
        _scoreCount += amount;
        UpdateScoreText();

        if (_scoreCount > _bestScore)
        {
            _bestScore = _scoreCount;
            PlayerPrefs.SetInt("BestScore", _bestScore);
            UpdateBestScoreText();
        }
    }

    private void UpdateScoreText()
    {
        ScoreText.text = $" {_scoreCount}";
    }

    private void UpdateBestScoreText()
    {
        BestScoreText.text = $" {_bestScore}";
    }

    public void ResetScore()
    {
        _scoreCount = 0;
        UpdateScoreText();
    }

}
