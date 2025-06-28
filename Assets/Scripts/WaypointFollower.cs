using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] bool isEnemy = false;
    [SerializeField] Animator animator;
    [SerializeField] GameObject[] waypoints;
    [SerializeField] int currentWaypointIndex = 0;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float rotationSpeed = 1.0f;

    private void Start()
    {
        if (isEnemy)
        {
            Vector3 directionToTarget = waypoints[currentWaypointIndex].transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 10000);
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < 0.1f)
        {

            if (currentWaypointIndex + 1 >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            else
            {
                currentWaypointIndex += 1;
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
        if (isEnemy)
        {
            animator.SetBool("IsMoving", true);
            Vector3 directionToTarget = waypoints[currentWaypointIndex].transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
