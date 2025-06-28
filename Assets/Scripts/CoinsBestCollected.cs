using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsBestCollected : MonoBehaviour
{
    [SerializeField] Text[] levelTexts;
    private void Start()
    {
        UpdateLevelTexts();
    }
    public void UpdateLevelTexts()
    {
        if (GameManager.Instance != null && GameManager.Instance.MaxCoinsPerLevel.Length >= levelTexts.Length)
        {
            for (int i = 0; i < levelTexts.Length; i++) {
                levelTexts[i].text = $"{GameManager.Instance.MaxCoinsPerLevel[i]}/5";
            }
        }
        else
        {
            Debug.LogError("GameManager is not set up correctly or does not have enough level data.");
        }
    }
}
