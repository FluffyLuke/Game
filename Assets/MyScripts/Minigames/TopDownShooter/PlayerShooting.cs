using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;      // The point from which bullets are fired.
    public GameObject bulletPrefab;  // The bullet prefab to instantiate.
    public float bulletSpeed = 10f;  // The speed of the bullet.
    public float fireRate = 0.5f;    // Time between shots in seconds.

    private float nextFireTime = 0f; // Time of the next allowed shot.

    public AudioSource audioSource;
    public AudioClip sfx1;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate; // Set the next allowed shot time.

            Shoot();
        }
    }

    void Shoot()
    {
        audioSource.clip = sfx1;
        audioSource.Play();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = (mousePosition - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(shootDirection.x * bulletSpeed, shootDirection.y * bulletSpeed);
    }
}
