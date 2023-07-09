using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerNameMenu;
    public GameObject mainMenu;
    public GameObject leaderboardMenu;
    public GameObject demoMenu;

    public void PlayerName()
    {
        mainMenu.gameObject.SetActive(false);
        playerNameMenu.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LeaderBoard()
    {
        mainMenu.gameObject.SetActive(false);
        leaderboardMenu.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Demo()
    {
        mainMenu.gameObject.SetActive(false);
        demoMenu.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void BackToMainMenuLB()
    {
        mainMenu.gameObject.SetActive(true);
        leaderboardMenu.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void BackToMainMenuDemo()
    {
        mainMenu.gameObject.SetActive(true);
        demoMenu.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
