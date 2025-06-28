using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float lifetime = 8f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
