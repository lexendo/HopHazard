using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsCollectedNow : MonoBehaviour
{
    [SerializeField] Text textField;
    void Start()
    {

        textField.text = $"Coins Collected: {GameManager.Instance.CoinsTemp}/5";
        Debug.Log("Coins set");

    }
}
