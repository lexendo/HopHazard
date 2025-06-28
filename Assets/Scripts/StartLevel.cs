using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public void startLevel(int level = 1)
    {
        SceneManager.LoadScene((level + 2));
    }
}
