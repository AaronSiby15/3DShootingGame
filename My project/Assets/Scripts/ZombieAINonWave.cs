using UnityEngine;
using UnityEngine.AI;


public class ZombieAINonWave : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
   

    [Header("Combat")]
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public int damage = 10;
    public GameObject xpGem;
    public int speed = 3;
    private float agroRange = 20f;
    private float stopChasingRange = 25f;
    private bool isPlayerInRange;
    private float lastAttackTime;

    [Header("Health")]
    public float maxHealth = 50f;
    private float currentHealth;
    
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

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
                animator.SetTrigger("isAttacking");
                AttackPlayer();
            }
            if (distanceToPlayer <= agroRange)
            {
                // Start chasing
                isPlayerInRange = true;
                agent.isStopped = false;
                agent.SetDestination(player.position);
                animator.SetTrigger("isAgro");
            }
            else if (distanceToPlayer >= stopChasingRange)
            {
                // Stop chasing if out of range
                isPlayerInRange = false;
                agent.isStopped = true;
                agent.ResetPath();
                animator.SetTrigger("isFar");
            }
            else if (isPlayerInRange)
            {
                // Continue chasing if already chasing
                agent.SetDestination(player.position);
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
    animator.SetTrigger("isDead");
    if (xpGemPrefab != null)
    {
        Instantiate(xpGemPrefab, transform.position + Vector3.up, Quaternion.identity);
        Debug.Log("Spawned XP Gem");
    }
    else
    {
        Debug.LogError("Could not load xpGem prefab from Resources!");
    }

    Destroy(gameObject);
    Debug.Log("Zombie Died!");
}
}