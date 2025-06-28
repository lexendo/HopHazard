using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    [SerializeField] int level;
    void Start()
    {
        GameManager.Instance.StartLevel(level);
    }
}
