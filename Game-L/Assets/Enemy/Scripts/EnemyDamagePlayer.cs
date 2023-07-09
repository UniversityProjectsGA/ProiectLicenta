using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayer : MonoBehaviour
{
    public float damageAmount = 5f;
    public float damageInterval = 2.5f;
    public float soundStartDistance = 15f;
    public float soundStopDistance = 2f;
    public AudioClip moveSound;
    public AudioClip damageSound;
    private Transform player;
    private float nextDamageTime;
    private bool canDealDamage = false;
    private bool isAttacking = false;
    private AudioSource audioSource;
    public EnemyHP enemyHP;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextDamageTime = Time.time + damageInterval;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time >= nextDamageTime)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= soundStartDistance && audioSource != null && moveSound != null)
            {
                if (!audioSource.isPlaying && enemyHP.health > 0)
                {
                    audioSource.clip = moveSound;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
            else if (distance > soundStopDistance && audioSource != null)
            {
                audioSource.Stop();
            }
            
            if (distance <= 2f && !isAttacking)
            {
                StartCoroutine(WaitToDamage());
                if (canDealDamage == true)
                {
                    PlayerHP playerHealth = player.GetComponent<PlayerHP>();
                    if (playerHealth != null && enemyHP.health > 0)
                    {
                        playerHealth.TakeDamage(damageAmount);
                        isAttacking = true;
                        StartCoroutine(PlayAttackSound());
                    }
                    nextDamageTime = Time.time + damageInterval;
                }
            }
            if (distance >= 2f)
                canDealDamage = false;
        }
    }

    IEnumerator WaitToDamage()
    {
        yield return new WaitForSeconds(1f);
        canDealDamage = true;
    }

    private IEnumerator PlayAttackSound()
    {
        if (audioSource != null && damageSound != null)
        {
            audioSource.Stop();
            audioSource.clip = damageSound;
            audioSource.loop = false;
            audioSource.Play();
            yield return new WaitForSeconds(damageSound.length);
            isAttacking = false;
        }
    }
}
