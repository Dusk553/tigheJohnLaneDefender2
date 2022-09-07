using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobController : MonoBehaviour
{
    private playerLives playerlivesInstance;

    public float speed;
    public float health;
    private float timer;
    public Animator hit;

    public AudioSource source;
    public AudioClip hitSound;
    public AudioClip deathSound;

    private void Start()
    {
        playerlivesInstance = GameObject.FindObjectOfType<playerLives>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;

        if (gameObject.name == "slime(Clone)" && timer <= 0)
        {
            speed = 2;
        }

        if (gameObject.name == "snail(Clone)" && timer <= 0)
        {
            speed = 1;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (health == 0)
        {
            source.PlayOneShot(deathSound);
            playerlivesInstance.UpdateScore();
            hit.SetBool("dead", true);
        }
    }
    IEnumerator Damage()
    {
        source.PlayOneShot(hitSound);
        hit.SetBool("hit", true);
        yield return new WaitForSeconds(.5f);
        hit.SetBool("hit", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.name == "Defend Line")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            speed = 0;
            StartCoroutine(Damage());
            timer = .5f;

        }
    }

    public void dead()
    {
        Destroy(gameObject);
    }
}

