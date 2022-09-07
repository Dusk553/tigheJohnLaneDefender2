using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float speed = 3f;

    public playerLives playerLivesIntance;
    private float timer = .5f;
    private bool canShoot = true;
    public GameObject bullet;
    public GameObject cannon;

    public AudioSource source;
    public AudioClip gunshot;

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (canShoot == true && Input.GetKey(KeyCode.Space))
        {
            shootBullet();
        }

        if (canShoot == false && timer <= 0)
        {
            canShoot = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerLivesIntance.UpdateLives();
        }
    }
    void shootBullet()
    {
        source.PlayOneShot(gunshot);
        Instantiate(bullet, cannon.transform.position, Quaternion.identity);
        canShoot = false;
        timer = .5f;
    }


}
