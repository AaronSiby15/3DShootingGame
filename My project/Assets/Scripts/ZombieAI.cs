using UnityEngine;
using UnityEngine.AI;


public class ZombieAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
   

    [Header("Combat")]
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public int damage = 10;
    public GameObject xpGem;

    private float lastAttackTime;

    [Header("Health")]
    public float maxHealth = 50f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        agent = GetComponent<NavMeshAgent>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the Player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
        }
    }

    void AttackPlayer()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            Debug.Log("Zombie Attacked Player!");

            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Zombie took damage: " + amount + " | Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            
            Die();
        }
    }

    void Die()
{
    GameObject xpGemPrefab = Resources.Load<GameObject>("xpSphere");

    if (xpGemPrefab != null)
    {
        Instantiate(xpGemPrefab, transform.position + Vector3.up, Quaternion.identity);
        Debug.Log("Spawned XP Gem");
    }
    else
    {
        Debug.LogError("Could not load xpGem prefab from Resources!");
    }
    WaveManager.Instance.ZombieDied();
    Destroy(gameObject);
    Debug.Log("Zombie Died!");
}
}