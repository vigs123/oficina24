using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public static GameController instance;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
    public void ShowGameOver()
    {
      gameOver.SetActive(true);
    }
    public void restartGame(string lvlname)
    {
       SceneManager.LoadScene(lvlname);
    }
}
