using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float health = 500f;
    public Slider hpSlider;
    private UIManager uiManager;
    public GameObject Menu;

    void Start()
    {
        uiManager = GameObject.Find("CanvasPlayerUI").GetComponent<UIManager>();
    }

    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if(health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Menu.gameObject.SetActive(true);
    }

    void Update() {
        hpSlider.value = health;
        if (uiManager.isTimerFinished == true)
        {
            Die();
        }
    }
}
