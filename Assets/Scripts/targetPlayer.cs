using UnityEngine;

public class targetPlayer : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireRate = 1.0f;
    public float laserSpeed = 10.0f; // Adjust the speed as needed
    private float nextFireTime;

    void Start()
    {
        nextFireTime = Time.time + 1 / fireRate;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            ShootLaser();
            nextFireTime = Time.time + 1 / fireRate;
        }
    }

    void ShootLaser()
    {
       GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

        // Set the velocity of the laser to shoot downwards
        rb.velocity = Vector2.down * laserSpeed;

        // Destroy the laser after a certain time (e.g., 2 seconds)
        Destroy(laser, 2f);
    }


}
