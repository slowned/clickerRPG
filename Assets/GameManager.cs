using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro; // using for ProUGUI


public class GameManager : MonoBehaviour {
  public int score;
  public TextMeshProUGUI scoreText;

  public bool isGameActive;
  public TextMeshProUGUI gameOverText;

  public Button restartButton;

  void Start() {
    isGameActive = true;
  }

  public void UpdateScore() {
    score += 1;
    scoreText.text = "Kills: " + score;
  }

  public void GameOver() {
    isGameActive = false;
    gameOverText.gameObject.SetActive(true);
    restartButton.gameObject.SetActive(true);
  }

  public void RestarGame() {
    // nombre de la scena tring
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}
