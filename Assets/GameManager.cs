using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro; // using for ProUGUI


public class GameManager : MonoBehaviour {
  public int score;
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI waveLevelText;

  public bool isGameActive;
  public TextMeshProUGUI gameOverText;

  public Button restartButton;

  void Start() {
    isGameActive = true;
  }

  public void GameOver() {
    isGameActive = false;
    gameOverText.gameObject.SetActive(true);
    restartButton.gameObject.SetActive(true);
    Invoke("PauseGame", 0.5f);
  }

  public void PauseGame() {

    Time.timeScale = 0f;
  }

  public void RestarGame() {
    // nombre de la scena tring
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    Time.timeScale = 1f;
  }

  public void UpdateScore() {
    score += 1;
    scoreText.text = "Kills: " + score;
  }

  public void UpdateWaveLevel(int _level) {
    waveLevelText.text = "Wave: " + _level;
  }

}
