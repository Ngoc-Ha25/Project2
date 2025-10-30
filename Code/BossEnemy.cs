using UnityEngine;
using UnityEngine.Assertions.Must;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedDanThuong = 20f;
    [SerializeField] private float speedDanVongTron = 10f;
    [SerializeField] private float hpValue = 100f;
    [SerializeField] private GameObject miniEnemy;
    [SerializeField] private float skillCooldown = 2f;
    [SerializeField] private GameObject usbPrefabs;

    private float nextSkillTime = 0f;
    protected override void Update()
    {
        base.Update();
       if(Time.time > nextSkillTime)
        {
            SuDungSkill();
        }
    }
    protected override void Die()
    {
        Instantiate(usbPrefabs, transform.position, Quaternion.identity);
        base.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Player != null)
            {
                Player.TakeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Player != null)
            {
                Player.TakeDamage(stayDamage);
            }
        }
    }

    private void BanDanThuong()
    {
        if (Player != null)
        {
            Vector3 directionToPlayer = Player.transform.position-firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedDanThuong);
        }
    }
    private void BanDanTron()
    {
        const int bulletCount = 12;
        float anglestep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * anglestep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad*angle),Mathf.Sin(Mathf.Deg2Rad*angle),0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection * speedDanVongTron);
        }
    }
    private void HoiMau(float hpAmount)
    {
        currentHp = Mathf.Min(currentHp + hpAmount, maxHp);
        UpdateHpBar();

    }
    private void SinhMiniEnemy()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);
    }
    private void DichChuyen()
    {
        if(Player != null)
        {
            transform.position = Player.transform.position;
        }
    }
    private void ChonSkillNgauNhien()
    {
        int randomSkill = Random.Range(0, 5);
        switch (randomSkill)
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanTron();
                break;
            case 2:
                HoiMau(hpValue);
                break;
            case 3:
                DichChuyen();
                break;
            case 4:
                SinhMiniEnemy();
                break;

        }
    }
    private void SuDungSkill()
    {
        nextSkillTime = Time.time + skillCooldown;
        ChonSkillNgauNhien();
    }
}
