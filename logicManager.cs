using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class logicManager : MonoBehaviour
{
    public int scoreToAdd;
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public logicManager logic;

    private void Start()
    {

    }

    void Update()
    {

    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        Debug.Log("New Score: " + playerScore); // Add this line for debugging
        scoreText.text = playerScore.ToString();
    }
}
