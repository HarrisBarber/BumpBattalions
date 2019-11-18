using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    Health health;
    SpriteRenderer sprite;
    public int ID = 0;
    [SerializeField]
    private int damage = 5;
    private bool dead = false;
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

        if (health.getHealth() <= 0 && !dead)
        {
            if (ID != 0)
            {
                PlayerCommander.instance.unitDeath(ID == 1);
                dead = true;
            }
            else
            {
                Destroy(gameObject);
                dead = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
