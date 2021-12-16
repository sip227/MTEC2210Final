using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;

    public GameObject shot;
    public Text winText;

    public float fireRate = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("EnemyMovement", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    // Update is called once per frame
    void EnemyMovement()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyHolder) 
        {
            if (enemy.position.x < -10.5 || enemy.position.x > 10.5) 
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (Random.value > fireRate) 
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }
            if (enemy.position.y <= -4) 
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (enemyHolder.childCount == 1) 
        {
            CancelInvoke();
            InvokeRepeating("EnemyMovement", 0.1f, 0.25f);
        }

        if (enemyHolder.childCount == 0) 
        {
            winText.enabled = true;
        }
    }
}
