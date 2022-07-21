using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelsPanel;
    [SerializeField] GameObject mainMenuPanel;

    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ShowHideLevels()
    {
        if (levelsPanel.activeInHierarchy)
        {
            levelsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
        else
        {
            mainMenuPanel.SetActive(false);
            levelsPanel.SetActive(true);
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}
