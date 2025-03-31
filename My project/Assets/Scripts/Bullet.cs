using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 5f;

    private void Start()
    {
       // Destroy(gameObject, lifeTime);
    }

   private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Zombie"))
    {
        Debug.Log("Triggered zombie!");

        ZombieAI zombie = other.GetComponent<ZombieAI>();
        if (zombie != null)
        {
            zombie.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

 
    }

