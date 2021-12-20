using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -10) 
        {
            Destroy(bullet.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "PlayerCanon") 
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
        }
    }
}
