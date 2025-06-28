using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathAudio;
    [SerializeField] Transform modelTransform;
    [SerializeField] Animator playerAnimator;
    //private Animator enemyAnimator;
    bool dead = false;

    private void Start()
    {
        /*GameObject enemyGameObject = GameObject.FindGameObjectWithTag("Watcher");
        if (enemyGameObject != null)
        {
            enemyAnimator = enemyGameObject.GetComponent<Animator>();
        }*/
    }
    private void Update()
    {
        if (transform.position.y < -4 && dead == false)
        {
            Debug.Log("wtf" + transform.position.y);
            Die(true);
            dead = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GameObject watcher = collision.gameObject.transform.parent.gameObject;
            Animator enemyAnimator = watcher.GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("Attack");
            }

            Die(false);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Debug.Log("zabija ma " + collision.gameObject.name);
            Die(false);
            Destroy(collision.gameObject);
        }
    }
    void Die(bool fall = false)
    {
        if (fall == false)
        {
            playerAnimator.SetTrigger("WasHit");
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(DisableAfterDelay());
        }
        else
        {
            Invoke(nameof(ReloadLevel), 1);
            dead = true;
        }
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        playerAnimator.SetBool("IsDyingAlready", true);
        yield return new WaitForSeconds(2.5f);

        GetComponent<MeshRenderer>().enabled = false;
        modelTransform.gameObject.SetActive(false);
        

        deathAudio.Play();
        Invoke(nameof(ReloadLevel), 1);
        dead = true;
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
