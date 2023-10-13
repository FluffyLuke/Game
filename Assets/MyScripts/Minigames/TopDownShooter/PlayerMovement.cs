using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the player's movement speed as needed.
    public float rotationSpeed = 5f;

    private Rigidbody2D rb;

    public Animator anim;

    public GameObject spawnEnemy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get input for player movement.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the player's movement vector.
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply the movement to the Rigidbody.
        rb.velocity = movement * moveSpeed;

        if(horizontalInput == 0f && verticalInput == 0f)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("moving", false);
        }
        else
        {
            anim.SetBool("moving", true);
        }
    }

    private void Update()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction vector from the player to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the player to face the mouse position
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle-90f, Vector3.forward), rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            spawnEnemy.GetComponent<SpawnEnemy>().Died();
            transform.position = new Vector2(0f, 0f);
        }
    }
}