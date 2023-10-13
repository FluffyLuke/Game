using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the enemy moves.
    public float shootingRange = 5f; // Range at which the enemy stops to shoot.
    public float rotationSpeed = 180f; // Speed at which the enemy rotates.
    public float shootInterval = 2f; // Time interval between shots.
    public Transform shootingPoint; // Transform where bullets are instantiated.
    public GameObject bulletPrefab; // Prefab for the enemy's bullets.
    private Transform player;
    private float lastShotTime;

    public Animator anim;

    public GameObject blood;

    private void Start()
    {
        // Find the player object in the scene by its tag (You can change this to a different method if needed).
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Initialize the last shot time to start shooting immediately.
        lastShotTime = Time.time - shootInterval;
    }

    private void Update()
    {
        // Check if the player object is found.
        if (player == null)
        {
            Debug.LogWarning("Player not found!");
            return;
        }

        // Calculate the distance to the player.
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Calculate the direction to the player.
        Vector2 moveDirection = (player.position - transform.position).normalized;

        // Rotate the enemy to face the player.
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Move towards the player if not in shooting range.
        if (distanceToPlayer > shootingRange)
        {
            // transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
            // Stop moving when in shooting range.
            if (Time.time - lastShotTime >= shootInterval)
            {
                Shoot();
                lastShotTime = Time.time;
            }
        }
    }

    private void Shoot()
    {
        // Check if a bullet prefab has been assigned.
        if (bulletPrefab != null)
        {
            // Instantiate a bullet at the shooting point.
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

            // Calculate the direction to the player.
            Vector2 shootDirection = (player.position - shootingPoint.position).normalized;

            // Get the bullet's Rigidbody2D and set its velocity (adjust bullet speed as needed).
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = shootDirection * 10f; // Change 10f to your desired bullet speed.
        }
        else
        {
            Debug.LogWarning("Bullet prefab not assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            Instantiate(blood, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
