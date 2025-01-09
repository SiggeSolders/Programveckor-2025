using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    bool isAlive = true;
    bool isCarried = false;
    [SerializeField] GameObject player;

    private void Update()
    {
        if (isCarried)
        {
            transform.position = (player.transform.position += new Vector3(0, 0, 2));
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        isAlive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isAlive == false)
        {
            print("ded");
            if(collision.gameObject.layer == 6)
            {
                print("layer");
                isCarried = true;
            }
        }
    }
}
