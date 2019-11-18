using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health;
    [SerializeField]
    private float maxHealth = 100;
    [SerializeField]
    private float regenRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCommander.instance.play)
        {
            health = health + regenRate >= maxHealth ? maxHealth : health + regenRate;
        }
    }

    public void TakeDamage(float damage)
    {
        if (PlayerCommander.instance.play)
        {
            health -= damage;
        }
    }

    public float getHealth()
    {
        return health;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }
}
