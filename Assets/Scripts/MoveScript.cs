using JetBrains.Annotations;
using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveScript : MonoBehaviour
{
    public GameObject Enemy1;
    public Transform startPosition; // The starting position
    public Transform endPosition;   // The ending position
    public float moveSpeed = 3.0f; // Movement speed of the robot
    private Vector3 zAngle; //set the variable for the angle the cannon starts at
    public float angle = 1.0f;
    public GameObject playerTank;
    private bool movingToEnd = true;
    public float angleOffset = 180f;
    private void Update()
    {
        // Calculate the direction to move
        Vector3 targetPosition = movingToEnd ? endPosition.position : startPosition.position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        // Move the enemy
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Check if the enemy has reached the target position
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distanceToTarget < 0.1f)
        {
            // Switch direction
            movingToEnd = !movingToEnd;
        }


    }



}