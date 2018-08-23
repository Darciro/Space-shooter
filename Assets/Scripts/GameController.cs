using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Button restartButton;
	public Text scorePointsText;
	public int scorePoints = 0;

	public void AddPointToScore() {
		this.scorePoints += 1;
		this.scorePointsText.text = scorePoints.ToString();
	}

	public void RestartGame() {
		SceneManager.LoadScene("MainScene");
	}

	public void ShowRestartGameButton() {
		this.restartButton.gameObject.SetActive(true);
	}

}
