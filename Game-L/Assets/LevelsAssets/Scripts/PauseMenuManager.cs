using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject TFCameraPlayer;
    public GameObject TFCameraPlayerUI;
    public GameObject Enemyes;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            TFCameraPlayer.SetActive(false);
            TFCameraPlayerUI.SetActive(false);
            Enemyes.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
    }
}