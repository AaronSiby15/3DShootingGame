using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Bullet Variables")]
    public float bulletSpeed;
    public float fireRate, bulletDamage;
    public bool isAuto;

    [Header("Initial Setup")]
    public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    void Start()
    {

    }

    void Update()
    {
        if (isAuto)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // Add auto-fire logic if needed
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

   void Shoot()
{
    GameObject systemParent = GameObject.FindGameObjectWithTag("System");
    
    GameObject bullet;

    if (systemParent != null)
    {
        bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, systemParent.transform);
    }
    else
    {
        Debug.LogWarning("No object with tag 'System' found! Spawning bullet with no parent.");
        bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
    }

    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
    }

    Bullet bulletScript = bullet.GetComponent<Bullet>();
    if (bulletScript != null)
    {
        bulletScript.damage = bulletDamage;
    }
}
}