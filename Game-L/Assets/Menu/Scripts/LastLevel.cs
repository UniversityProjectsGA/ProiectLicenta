using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevel : MonoBehaviour
{
    private Leaderboard leaderboard;
    public GameObject TFCameraPlayer;
    public GameObject TFCameraPlayerUI;
    public GameObject Enemyes;

    private void Start()
    {
        GameObject canvasLeaderboard = GameObject.Find("LeaderboardMenu");
        leaderboard = canvasLeaderboard.GetComponent<Leaderboard>();
        Cursor.visible = true;
        TFCameraPlayer.SetActive(false);
        TFCameraPlayerUI.SetActive(false);
        Enemyes.SetActive(false);
    }

    public void LastLevelToMM()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        int score = PlayerPrefs.GetInt("PlayerScore");

        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();

        leaderboard.AddScore(playerName, score);

        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        int score = PlayerPrefs.GetInt("PlayerScore");

        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();

        leaderboard.AddScore(playerName, score);
        Application.Quit();
    }
}
