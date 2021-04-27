using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRoboScript : MonoBehaviour
{
    public float speed;
    public bool vertical;
    Rigidbody2D rigidbody2D;
    Animator animator;
    public int health { get { return currentHealth; } }
    int currentHealth;
    public int maxHealth = 10;

    private Transform mtarget;

    AudioSource audioSource;
    public AudioSource musicSource;
    public AudioClip walking;
    public AudioClip destroyed;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = 10;

        mtarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        musicSource.clip = walking;
        musicSource.Play();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, mtarget.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, mtarget.position, speed * Time.deltaTime);
        }

        if (currentHealth < 1)
        {
            musicSource.clip = walking;
            musicSource.Stop();
            musicSource.clip = destroyed;
            musicSource.Play();
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        if (currentHealth > 0)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-3);
        }

        Projectile projectile = other.gameObject.GetComponent<Projectile>();

        if (projectile != null)
        {
            currentHealth = currentHealth - 1;
            Debug.Log(currentHealth + "/" + maxHealth);
        }
    }
}