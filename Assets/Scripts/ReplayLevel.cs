using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayLevel : MonoBehaviour
{
    public void replayLevel()
    {
        SceneManager.LoadScene(GameManager.Instance.lastScene);
    }
}
