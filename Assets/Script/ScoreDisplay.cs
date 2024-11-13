using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Subscriber Class to the Score Manager
/// </summary>
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI textHigh;

    private void Awake()
    {
        if (text == null)
        {
            GameObject score = GameObject.FindGameObjectWithTag("Player");
            text = score.GetComponent<TextMeshProUGUI>();
        } else if (textHigh == null)
        {
            GameObject score = GameObject.FindGameObjectWithTag("Finish");
            textHigh = score.GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GM instance is null");
        } else
        {
            textHigh.text = "High Score: "+ GameManager.Instance.HighScore;
        }

    }

    private void OnEnable()
    {
        // Check if ScoreManager.Instance is available
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.onScoreChanged += updateScoreDisplay;
        }
        else
        {
            Debug.LogError("ScoreManager instance is null.");
        }
    }

    private void OnDisable()
    {
        ScoreManager.Instance.onScoreChanged -= updateScoreDisplay;
    }

    private void updateScoreDisplay(int newScore)
    {
        text.text = "Score: " + newScore;
        GameManager.Instance.UpdateHighScore(newScore);
    }

}
