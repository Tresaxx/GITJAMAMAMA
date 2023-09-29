using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    //public GameObject Shield;
    public GameObject Boom;
    public int health = 2;
    public int shield = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (health <= 0)
        {
            Destroy(gameObject.transform.root.gameObject);
            Explode();
        }
    }
    public void TakeDamage(int damage)
    {
        //if (shield > 0)
        //{
        //    shield--;
        //    print("Shield took damage");
        //}

        //else if (shield <= 0)
        //{
        //    //Destroy(Shield);
        //        health--;
        //}
       health -= damage;

    }

    private void Explode()
    {
  
        GameObject explosion = Instantiate(Boom, transform.position, Quaternion.identity);



        //destroys the explosion
        Destroy(explosion, 1.0f);

        //de
        Destroy(gameObject);
    }
}
