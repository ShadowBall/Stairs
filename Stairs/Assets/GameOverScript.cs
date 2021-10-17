using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;
    public Text highScore;
    public Text newHighScore;
    public GameObject JumpButton;
    public GameObject ReverseJumpButton;

    // Start is called before the first frame update
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        JumpButton.SetActive(false);
        ReverseJumpButton.SetActive(false);
        if (ScoreScript.scoreValue > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ScoreScript.scoreValue);
            newHighScore.text = "New High Score: " + score.ToString() + " POINTS";
        }
        else
        {
            highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString() + " POINTS";
        }
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("Game");
    }

    public void MainMenuButton()
    {   
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("Menu");
    }
}
