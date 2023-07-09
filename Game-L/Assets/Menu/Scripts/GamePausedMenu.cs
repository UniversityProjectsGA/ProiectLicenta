using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePausedMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject TFCameraPlayer;
    public GameObject TFCameraPlayerUI;
    public GameObject Enemyes;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        TFCameraPlayer.SetActive(false);
        TFCameraPlayerUI.SetActive(false);
        Enemyes.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        TFCameraPlayer.SetActive(true);
        TFCameraPlayerUI.SetActive(true);
        Enemyes.SetActive(true);
        TFCameraPlayerUI.GetComponent<UIManager>().RestartTimer();
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
