using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    private Rigidbody2D myBodyy;
    public int playerHealth = 2;
    public GameObject Boom;

    // Start is called before the first frame update
    void Start()
    {
        myBodyy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiztonal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horiztonal, vertical);
        movement.Normalize();
        myBodyy.velocity = movement * moveSpeed;

        if (playerHealth <= 0)
        {
            Destroy(gameObject.transform.root.gameObject);
            Explode();
        }
    }

    public void PlayerDamage(int damage1)
    {
        playerHealth -= damage1;
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(Boom, transform.position, Quaternion.identity);

        // Destroys the explosion
        Destroy(explosion, 1.0f);

        // Destroy the tank
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            PlayerDamage(1);

        }
    }
}
