using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public int score = 0;
	public TextMeshProUGUI ScoreText;
	public TextMeshProUGUI ScoreText2;
	public TextMeshProUGUI ScoreText3;
	public TextMeshProUGUI ScoreText4;
	public bool gameOver;
	public GameObject gameOverPanel;
	public int bestScore;

	void Start() {
		LoadPlayer();
		ScoreText.text = "Score: " + score;
	}


	void Update() {

	}

	public void UpdateScore(int points) {
		score += points;
		ScoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOver = true;
		gameOverPanel.SetActive(true);
		ScoreText.text = " ";
		ScoreText2.text = "Score: " + score;
		ScoreText4.text = "Best Score: " + bestScore;
		if (score > bestScore)
			ScoreText3.text = "NEW RECORD";
		else
			ScoreText3.text = " ";
		SavePlayer();
	}

	public void PlayAgain() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}

	public void Menu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void MainMenu () {

    }

	private void SavePlayer ()
    {
		if (score > bestScore)
			bestScore = score;
		SaveSystem.SaveScore(this);
    }

	private void LoadPlayer ()
    {
		PlayerData data = SaveSystem.LoadScore();
		if (data != null)
			bestScore = data.bestScore;
	}
}