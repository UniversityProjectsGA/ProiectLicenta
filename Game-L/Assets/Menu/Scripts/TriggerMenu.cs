using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerMenu : MonoBehaviour
{
    public GameObject Menu;

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            Menu.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
