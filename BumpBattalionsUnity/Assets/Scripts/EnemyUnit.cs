using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    Health health;
    SpriteRenderer sprite;
    [SerializeField]
    private float damage = 5;
    [SerializeField]
    private bool chaser;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, (health.getHealth() / health.getMaxHealth()) / 2 + 0.5f);
        if (health.getHealth() <= 0)
        {
            Destroy(gameObject);
        }

        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
