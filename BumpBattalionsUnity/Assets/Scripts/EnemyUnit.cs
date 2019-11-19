using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    Health health;
    SpriteRenderer sprite;
    Movement movement;
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
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, (health.getHealth() / health.getMaxHealth()) / 2 + 0.5f);
        if (health.getHealth() <= 0)
        {
            Destroy(gameObject);
        }

        if (chaser)
        {
            if (target == null)
            {
                PlayerUnit[] foundObjs = FindObjectsOfType<PlayerUnit>();

                Vector3 nearestDist = new Vector3(float.MaxValue, float.MaxValue);

                foreach (PlayerUnit unit in foundObjs)
                {
                    Vector3 dist = unit.transform.position - transform.position;
                    if (dist.magnitude < nearestDist.magnitude)
                    {
                        nearestDist = dist;
                        target = unit.gameObject;
                    }
                }
            }

            movement.SetMovementAxisValues(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
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
