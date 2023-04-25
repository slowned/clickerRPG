using UnityEngine;

public class StatsMenu : MonoBehaviour
{
  public static bool statsMenuIsOpen = false;
  public GameObject statsMenuUI;
  
  void Start() { }

  void Update() {
    if (Input.GetKeyDown(KeyCode.C)) {
      if (statsMenuIsOpen) {
        CloseStatsMenu();
      } else {
        OpenStatsMenu();
      }
    }
  }

  public void OpenStatsMenu() {
    Debug.Log("ABRO CHARACTER STATS");
    statsMenuUI.SetActive(true);
    statsMenuIsOpen = true;
  }

  public void CloseStatsMenu() { 
    Debug.Log("CIERRo CHARACTER STATS");
    statsMenuUI.SetActive(false);
    statsMenuIsOpen = false;
  }
}
