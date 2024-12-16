using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Singleton for easy access
    public TextMeshProUGUI scoreText;     // Text component for displaying score
    private int score = 0;                // Player's score

    void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText(); // Initialize the score display
    }

    public void AddScore(int points)
    {
        score += points; // Add points to score
        Debug.Log("Score Updated: " + score); // Debug for Console
        UpdateScoreText(); // Update the UI text
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update text in UI
            Debug.Log("Updating Score Text: " + score);
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the Inspector!");
        }
    }
}


