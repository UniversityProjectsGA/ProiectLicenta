using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Leaderboard leaderboard;
    public GameObject TFCameraPlayer;
    public GameObject TFCameraPlayerUI;
    public GameObject Enemyes;

    private void Start()
    {
        Cursor.visible = true;
        TFCameraPlayer.SetActive(false);
        TFCameraPlayerUI.SetActive(false);
        Enemyes.SetActive(false);
        Time.timeScale = 0f;
        GameObject canvasLeaderboard = GameObject.Find("LeaderboardMenu");
        leaderboard = canvasLeaderboard.GetComponent<Leaderboard>();
    }

    public void Next()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        int score = PlayerPrefs.GetInt("PlayerScore");

        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();

        leaderboard.AddScore(playerName, score);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
