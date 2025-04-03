using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 5f;

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float LifeTime
    {
        get { return lifeTime; }
        set { lifeTime = value; }
    }

    public Bullet(float damage, float lifeTime)
    {
        this.damage = damage;
        this.lifeTime = lifeTime;
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Debug.Log("Triggered zombie!");

            ZombieAI zombie = other.GetComponent<ZombieAI>();
            ZombieAINonWave zombie2 = other.GetComponent<ZombieAINonWave>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage);
                Destroy(gameObject);
            }

            if (zombie2 != null)
            {
                zombie2.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}

