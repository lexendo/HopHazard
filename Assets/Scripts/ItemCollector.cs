using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public int counter = 0;
    [SerializeField] Text scoreText;
    [SerializeField] AudioSource collectCoin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            counter ++;
            collectCoin.Play();
            scoreText.text = "Score: " + counter.ToString();
        }
    }
}
