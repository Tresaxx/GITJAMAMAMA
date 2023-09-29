using JetBrains.Annotations;
using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class targetPlayer : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject laser;
    public Transform startPosition; // The starting position
    public Transform endPosition;   // The ending position
    public float moveSpeed = 3.0f; // Movement speed of the robot
    private Vector3 zAngle; //set the variable for the angle the cannon starts at
    public float angle = 1.0f;
    public GameObject playerTank;
    private bool movingToEnd = true;
    public float angleOffset = 180f;
    public float lastShot = 0.0f;
    public float gameTime = 0.0f;
    public float shootCooldown = 2.0f;
    private float bulletSpeed = 5.0f;
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

        Vector3 aimS = playerTank.transform.position;
        aimS.z = 0f;
        //gun follows the mouse
        //normalized, a vector keeps the same direction but it's length is 1.0
        Vector3 aimDirection = (aimS - transform.position).normalized;
        //atan2 - the angle in radians, between positive x axis an ray to the point x, y
        float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) - 90 + angleOffset;
        zAngle = new Vector3(0, 0, angle);
        //euler angles - 3 angles that describe the orientation of a rigid body in a coordinate system
        transform.eulerAngles = zAngle;


        Vector3 target1 = playerTank.transform.position;
        //cursor.transform.position = new Vector2(target.x, target.y);


        Vector3 difference1 = target1 - playerTank.transform.position;
        float distance1 = difference1.magnitude;
        Vector2 direction1 = difference1 / distance1;


        if (lastShot + 2 <= gameTime)
        {
            Vector3 difference = target1 - Enemy1.transform.position;
            float distance = difference1.magnitude;
            Vector2 direction = difference1 / distance1;
            //Normalize, keep vectors in same direction but length of 1 now
            direction1.Normalize();
            FireLaser(direction1, Enemy1.GetComponent<targetPlayer>().angle);
        }

    }

    void FireLaser(Vector2 Direction, float rotationZ)
    {
        GameObject tempBullet = Instantiate(laser) as GameObject;
        tempBullet.transform.position = Enemy1.transform.position;
        tempBullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        tempBullet.GetComponent<Rigidbody2D>().velocity = Direction * bulletSpeed;

    }

}
