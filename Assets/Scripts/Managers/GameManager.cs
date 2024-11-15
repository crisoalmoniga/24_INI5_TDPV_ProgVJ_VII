using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            score = 1000;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddScore(int points)
    {
        score += points;

        if(score <= 0)
        {
            ApplicationManager.Instance.GoToPreviousScene();
        }

    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }
}
