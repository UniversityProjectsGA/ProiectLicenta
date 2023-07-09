using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerNameMenu : MonoBehaviour
{
    public TMP_InputField nameInputField;
    
    public void SaveData()
    {
        string playerName = nameInputField.text;
        int score = 0;
        
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Level1");
    }
}
