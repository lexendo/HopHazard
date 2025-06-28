using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            NewBehaviourScript playerScript = other.gameObject.GetComponent<NewBehaviourScript>();

            if (playerScript != null)
            {
                
                int levelIndex = SceneManager.GetActiveScene().buildIndex - 3;
                GameManager.Instance.EndLevel(levelIndex);
                GameManager.Instance.UpdateLastScene(SceneManager.GetActiveScene().buildIndex);

                int currentCoins = playerScript.counter;
                GameManager.Instance.UpdateMaxCoins(currentCoins, levelIndex);
            }
            Debug.Log("loading scene");
            SceneManager.LoadScene(2);

        }
    }
}
