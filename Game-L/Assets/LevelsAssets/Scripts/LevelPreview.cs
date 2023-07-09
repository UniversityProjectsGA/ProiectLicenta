using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LevelPreview : MonoBehaviour
{
    public GameObject previewMenu;
    public VideoPlayer videoPlayer;
    public GameObject TFCameraPlayer;
    public GameObject TFCameraPlayerUI;
    public GameObject Enemyes;

    void Start()
    {
        Cursor.visible = true;
        TFCameraPlayer.SetActive(false);
        TFCameraPlayerUI.SetActive(false);
        Enemyes.SetActive(false);
        Time.timeScale = 0f;
        videoPlayer = GetComponentInChildren<VideoPlayer>();
    }
    public void ContinueToLevel()
    {
        videoPlayer.Stop();
        Time.timeScale = 1f;
        Cursor.visible = false;
        previewMenu.SetActive(false);
        TFCameraPlayerUI.SetActive(true);
        TFCameraPlayer.SetActive(true);
        Enemyes.SetActive(true);
    }
}
