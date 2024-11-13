using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Score Manager Singleton with an observer approach
public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance ==  null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if (instance ==  null)
                {
                    instance = new GameObject("ScoreManager").AddComponent<ScoreManager>();
                }
            }
            return instance;

        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public delegate void ScoreChange(int score);
    public event ScoreChange onScoreChanged;
    private int score;

    public void AddScore(int value)
    {
        score += value;
        onScoreChanged?.Invoke(score);
    }

    private void OnEnable()
    {
        Sphere.onSphereDestroyed += OnSphereDestroyed;
    }
    private void OnDisable()
    {
        Sphere.onSphereDestroyed -= OnSphereDestroyed;
    }

    private void OnSphereDestroyed(Sphere sphere)
    {
        AddScore(10);
    }
}

