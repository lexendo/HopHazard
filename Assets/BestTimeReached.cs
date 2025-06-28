using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeReached : MonoBehaviour
{
    [SerializeField] Text[] levelTexts;
    private void Start()
    {
        UpdateLevelTexts();
    }
    public void UpdateLevelTexts()
    {

        for (int i = 0; i < levelTexts.Length; i++)
         {
            levelTexts[i].text = GameManager.Instance.BestTime[i].ToString("Record: " + "00.0" + " s");;
            Debug.Log(GameManager.Instance.BestTime[i].ToString());
        }
    }
}

