using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;

    void Update()
    {
        transform.Rotate(360 * Time.deltaTime * speedX, 360 * Time.deltaTime * speedY, 360 * Time.deltaTime * speedZ);
    }
}
