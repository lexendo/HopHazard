using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompletedScene : MonoBehaviour
{
    int coinsSum = 0;
    [SerializeField] Text levelText;
    void Start()
    {
        if (GameManager.Instance != null)
        {

            for (int i = 0; i < GameManager.Instance.MaxCoinsPerLevel.Length; i++)
            {
                coinsSum += GameManager.Instance.MaxCoinsPerLevel[i];
            }

            levelText.text = $"Total coins collected: {coinsSum}/20";
            /*if (coinsSum == GameManager.Instance.MaxCoinsPerLevel.Length * 5)
            {
                SceneManager.LoadScene(7);
            }*/
        }
    }
}
