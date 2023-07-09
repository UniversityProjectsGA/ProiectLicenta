using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    public Text leaderboardText;
    private const int MaxScores = 5;

    private List<PlayerData> playerDataList;

    private void Start()
    {
        LoadLeaderboardData();
        UpdateLeaderboardText();
    }

    private void LoadLeaderboardData()
    {
        playerDataList = new List<PlayerData>();

        string leaderboardData = PlayerPrefs.GetString("LeaderboardData");

        if (!string.IsNullOrEmpty(leaderboardData))
        {
            playerDataList = JsonUtility.FromJson<LeaderboardData>(leaderboardData).playerDataList;
        }
    }

    private void SaveLeaderboardData()
    {
        playerDataList = playerDataList.OrderByDescending(playerData => playerData.score).ToList();

        if (playerDataList.Count > MaxScores)
        {
            playerDataList = playerDataList.Take(MaxScores).ToList();
        }

        string leaderboardData = JsonUtility.ToJson(new LeaderboardData(playerDataList));

        PlayerPrefs.SetString("LeaderboardData", leaderboardData);
        PlayerPrefs.Save();
    }

    public void AddScore(string playerName, int score)
    {
        PlayerData newPlayerData = new PlayerData(playerName, score);

        playerDataList.Add(newPlayerData);

        SaveLeaderboardData();
        UpdateLeaderboardText();
    }

    private void UpdateLeaderboardText()
    {
        leaderboardText.text = "";

        playerDataList = playerDataList.OrderByDescending(playerData => playerData.score).ToList();

        for (int i = 0; i < playerDataList.Count; i++)
        {
            leaderboardText.text += string.Format("{0}. {1} - {2}\n", i + 1, playerDataList[i].name, playerDataList[i].score);
        }
    }

    [System.Serializable]
    private class LeaderboardData
    {
        public List<PlayerData> playerDataList;

        public LeaderboardData(List<PlayerData> playerDataList)
        {
            this.playerDataList = playerDataList;
        }
    }

    [System.Serializable]
    private class PlayerData
    {
        public string name;
        public int score;

        public PlayerData(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
}