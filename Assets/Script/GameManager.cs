using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// Game manager Singleton
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI hs;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance ==  null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance ==  null)
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                } 
            }
            return instance;
        }
    }

    public int HighScore { get; private set; }
    private void Awake()
    {
        if (instance ==  null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (hs == null)
        {
            GameObject score = GameObject.FindGameObjectWithTag("Finish");
            hs = score.GetComponent<TextMeshProUGUI>();
            HighScore = 50;
        }
    }


    public void UpdateHighScore (int score)
    {
        if (score > HighScore)
        {
            HighScore = score;
            hs.text = "High Score: " + score;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            FalingObjects.Instance.CreateFallingObject("Spheres");
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            FalingObjects.Instance.CreateFallingObject("Cylinder");
        }
    }
}
