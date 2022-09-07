using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private float speed = 3;
    public Animator shot;
    private float timer = .5f;

    private void Start()
    {
        shot.SetBool("shot", true);
    }

    private void Update()
    {
        timer -= 1 * Time.deltaTime;
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (timer <= 0)
        {
            shot.SetBool("shot", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            speed = 0;
            shot.SetBool("hit", true);
        }
    }

    private void RemoveBullet()
    {
        Destroy(gameObject);
    }

}
