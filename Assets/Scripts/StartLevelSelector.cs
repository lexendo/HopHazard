using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevelSelector : MonoBehaviour
{
    public void LoadLevelSelector()
    {
        SceneManager.LoadScene(1);
    }
}
