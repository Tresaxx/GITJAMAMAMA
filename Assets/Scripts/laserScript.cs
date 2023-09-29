using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class laserScript : MonoBehaviour
{

    private Vector3 zAngle; //set the variable for the angle the cannon starts at
    public float angle = 1.0f;

    public float angleOffset = 180f;
    public float lastShot = 0.0f;
    public float gameTime = 0.0f;
    public float shootCooldown = 2.0f;
    Vector3 screenPoss;
    public int damage1 = 1;
    private void Update()
    {
        screenPoss = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPoss.x < 0 || screenPoss.y < 0 || screenPoss.z > Screen.width || screenPoss.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            TankMovement tankMovement = collision.gameObject.GetComponent<TankMovement>();
            tankMovement.PlayerDamage(damage1);

        }
        else if (collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
        }


    }

}
