using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Text CurrentScoreText;
    public Text BestScoreText;
    public Text distanceText;

    public GameObject Player;


    int currentScore;
    float currentDistance;
    

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        currentDistance = 0f;
        BestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Player.transform.position.y + 8.59f;
        SetDistanceScore();

    }
    public void CallGameOver()
    {
        StartCoroutine(GameOver());
        
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void AddScore()
    {
        currentScore++;
        if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", 0);
            BestScoreText.text = currentScore.ToString();
        }
        SetScore();
    }
    
    void SetScore()
    {
        CurrentScoreText.text = currentScore.ToString();
    }
    void SetDistanceScore()
    {
        distanceText.text = "Distance: " + currentDistance.ToString("F2");
    }

}
