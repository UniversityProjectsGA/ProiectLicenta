using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("PlayerScore");

        scoreText.text = " " + score.ToString();
    }
}