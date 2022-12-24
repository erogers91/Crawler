using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;

    public int health;
    public int damage = 1;
    public float attackChance = 0.5f;

    public GameObject deathDropPrefab;
    public SpriteRenderer sr;

    public LayerMask moveLayerMask;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            if (deathDropPrefab != null)
                Instantiate(deathDropPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        StartCoroutine(DamageFlash());

        if (Random.value > attackChance)
            player.TakeDamage(damage);
    }

    IEnumerator DamageFlash()
    {
        Color defaultColor = sr.color;
        sr.color = Color.red;

        yield return new WaitForSeconds(0.05f);
        if (sr.color != defaultColor)
            sr.color = defaultColor;
        sr.color = defaultColor;
    }

    public void Move()
    {
        if (Random.value < 0.5f)
            return;

        Vector3 dir = Vector3.zero;
        bool canMove = false;

        int i = 0;
        while (canMove == false)
        {
            dir = GetRandomDirection();
            // cast a ray into the direction.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 2.0f, moveLayerMask);
            // if the ray hasn't detected any obstacle,
            if (hit.collider == null)
                {canMove = true;}

            i++;
            if (i == 50)
                break;
        }        // move towards the direction
        transform.position += dir;
    }
    // returns a random direction - up, down, left or right
    Vector3 GetRandomDirection()
    {
        // Get a random number between 0 and 4
        int rand = Random.Range(0, 4);

        if (rand == 0)
            return Vector3.up;
        else if (rand == 1)
            return Vector3.down;
        else if (rand == 2)
            return Vector3.left;
        else if (rand == 3)
            return Vector3.right;
        return Vector3.zero;
    }
}