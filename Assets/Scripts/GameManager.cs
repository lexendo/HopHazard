using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int[] MaxCoinsPerLevel = new int[4];
    public int lastScene = 0;
    public int CoinsTemp = 0;

    public float[] BestTime = new float[4];
    public float lastTime = 0f;
    private float startTime;
    private bool timerIsActive = false;

    private Text currentTimeText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (timerIsActive && currentTimeText != null)
        {
            currentTimeText.text = ShowTime().ToString("00.0");
        }
    }


    public float ShowTime()
    {
        return timerIsActive ? Time.time - startTime : 0f;
    }

    public void StartLevel(int levelIndex)
    {

        currentTimeText = GameObject.Find("CurrentTime")?.GetComponent<Text>();
        if (currentTimeText == null)
        {
            Debug.LogWarning("CurrentTime text field not found in the scene.");
        }


        startTime = Time.time;
        timerIsActive = true;
        UpdateLastScene(levelIndex);
    }

    public void EndLevel(int levelIndex)
    {
        if (timerIsActive)
        {
            float endTime = Time.time;
            lastTime = endTime - startTime;
            timerIsActive = false;
            if (lastTime < BestTime[levelIndex] || BestTime[levelIndex] == 0)
            {
                BestTime[levelIndex] = lastTime;
            }

            Debug.Log("Level " + levelIndex + " completed in " + lastTime + " seconds.");
        }

    }
    public void DeactivateTimer()
    {
        timerIsActive = false;
    }


    public void UpdateMaxCoins(int newCoins, int levelIndex)
    {
        Debug.Log("update max coins" + newCoins + " , level index: " + levelIndex);
        if (newCoins > MaxCoinsPerLevel[levelIndex])
        {
            MaxCoinsPerLevel[levelIndex] = newCoins;
        }
        CoinsTemp = newCoins;
    }
    public void UpdateLastScene(int lastSceneNew)
    {
        lastScene = lastSceneNew;
    }

}
