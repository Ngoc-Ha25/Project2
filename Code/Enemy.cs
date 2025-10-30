using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected Player Player;
    [SerializeField] protected float maxHp = 50f;
    protected float currentHp;
    [SerializeField] private Image hpBar;

    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;

    protected virtual void Start()
    {
        Player = FindAnyObjectByType<Player>();
        currentHp = maxHp;
        UpdateHpBar();
    }
    protected virtual void Update()
    {
        MoveToPlayer();
    }
    protected void MoveToPlayer()
    {
        if (Player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }

    protected void FlipEnemy()
    {
        if (Player != null)
        {
            transform.localScale = new Vector3(Player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
        }
    }
    public virtual void TakeDamege(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
    protected void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }

    internal void TakeDamage(float damage)
    {
        throw new NotImplementedException();
    }
}

