using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
	public SafeInt score;
	public TextMeshProUGUI ScoreInPlayText;
	public TextMeshProUGUI ScoreOverText;
	public TextMeshProUGUI NewRecordText;
	public TextMeshProUGUI BestScoreText;
	public bool gameOver;
	public GameObject GameOverPanel;
	public GameObject PausePanel;
	public GameObject OptionsPanel;
	public GameObject MenuPanel;
	public GameObject LineControl;
	public SafeInt bestScore;

	void Start() {
		if (Advertisement.isSupported)
        {
			Advertisement.Initialize("3663803", true);
        }
		score = 0;
		LoadPlayer();
		MenuPanel.SetActive(true);
		gameOver = true;
	}

	public void UpdateScore(int points) {
		score += points;
		ScoreInPlayText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOver = true;
		GameOverPanel.SetActive(true);
		LineControl.SetActive(false);
		ScoreInPlayText.text = " ";
		ScoreOverText.text = "Score: " + score;
		BestScoreText.text = "Best Score: " + bestScore;
		if (score > bestScore)
			NewRecordText.text = "NEW RECORD";
		else
			NewRecordText.text = " ";
		SavePlayer();
	}

	public void PlayAgain() {
		score = 0;
		gameOver = false;
		GameOverPanel.SetActive(false);
		LineControl.SetActive(true);
		ScoreInPlayText.text = "Score: " + score;
	}

	public void Continue()
	{
		if (Advertisement.IsReady())
        {
			Advertisement.Show("video");
			Debug.Log("ADV");
		}
		Debug.Log("Cont");
		GameOverPanel.SetActive(false);
		LineControl.SetActive(true);
		gameOver = false;
		ScoreInPlayText.text = "Score: " + score;
	}

	public void MainMenu () {
		LineControl.SetActive(false);
		OptionsPanel.SetActive(false);
		GameOverPanel.SetActive(false);
		MenuPanel.SetActive(true);
	}

	public void Options()
	{
		MenuPanel.SetActive(false);
		OptionsPanel.SetActive(true);
	}

	public void Play()
	{
		score = 0;
		MenuPanel.SetActive(false);
		LineControl.SetActive(true);
		gameOver = false;
		ScoreInPlayText.text = "Score: " + score;
	}


	private void SavePlayer ()
    {
		if (score > bestScore)
			PlayerPrefsSafe.SetInt("Best", score);
	}

	private void LoadPlayer ()
    {
		bestScore = PlayerPrefsSafe.GetInt("Best", bestScore);
	}
}