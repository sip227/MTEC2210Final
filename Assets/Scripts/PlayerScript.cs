using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform player;

    public float speed;
    public float maxBound, minBound;
    public AudioSource audioSource;
    public AudioClip shootClip;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (player.position.x < minBound && h < 0)
        {
            h = 0;
        } else if (player.position.x > maxBound && h > 0) 
        {
            h = 0;
        }


    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            audioSource.PlayOneShot(shootClip);
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
