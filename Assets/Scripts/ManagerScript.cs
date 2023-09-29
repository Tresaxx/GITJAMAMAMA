using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject cannon;
    public GameObject tank;
    private float bulletSpeed = 5.0f;
    public const float MAXMOVEMENT = 100;
    public bool moving = false;
    public float movDirection;
    public string tankAxis;
    public GameObject cursor;
    private Vector3 mouseVector;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        mouseVector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(mouseVector);
        Vector3 playerTarget = tank.transform.position;
        //cursor.transform.position = new Vector2(target.x, target.y);


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 difference = target - cannon.transform.position;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            //Normalize, keep vectors in same direction but length of 1 now
            direction.Normalize();
            FirebBullet(direction, cannon.GetComponent<CannonScript>().angle);

        }

    }
    void FirebBullet(Vector2 Direction, float rotationZ)
    {
        GameObject tempBullet = Instantiate(bulletPrefab) as GameObject;
        tempBullet.transform.position = cannon.transform.position;
        tempBullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        tempBullet.GetComponent<Rigidbody2D>().velocity = Direction * bulletSpeed;

    }

}
