using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOfCompletion : MonoBehaviour
{
    private Text currentTimeText;
    void Start()
    {
        currentTimeText = GameObject.Find("LevelTime")?.GetComponent<Text>();
        currentTimeText.text = GameManager.Instance.lastTime.ToString("Time: " + "00.0" + " s");
    }

}
