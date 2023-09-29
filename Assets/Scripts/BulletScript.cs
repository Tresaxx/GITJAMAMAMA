using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 screenPos;
    public int damage = 1;
    void Update()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 || screenPos.y < 0 || screenPos.z > Screen.width || screenPos.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
          enemyHealth enemyHealth = collision.gameObject.GetComponent<enemyHealth>();
            enemyHealth.TakeDamage(damage);

        }
        else if (collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
        }
    }
}
