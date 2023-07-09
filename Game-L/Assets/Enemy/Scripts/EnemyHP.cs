using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider healthBar;
    public float health = 100f;
    public Animator animator;
    public AudioClip deathSound;
    public AudioSource audioSource;
    public int pointsToAward = 100;
    private UIManager uiManager;
    private Transform selfTransform;

    void Start()
    {
        selfTransform = transform;
        uiManager = GameObject.Find("CanvasPlayerUI").GetComponent<UIManager>();
        uiManager.UpdateScoreText(0);
    }
    public void TakeDamage(float ammount)
    {
        health -= ammount;
        if(health <= 0f)
        {
            selfTransform.GetComponent<CapsuleCollider>().enabled = false;
            uiManager.UpdateScoreText(pointsToAward);
            animator.SetTrigger("Death");
            PlayDeathSound();
            StartCoroutine(WaitToDelete());
        }
    }

    IEnumerator WaitToDelete()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void PlayDeathSound()
    {
        if (audioSource != null && deathSound != null)
        {
            audioSource.Stop();
            audioSource.clip = deathSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void Update() {
        healthBar.value = health;
    }
}
