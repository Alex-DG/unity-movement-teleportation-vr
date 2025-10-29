using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform firepoint;

    public float bulletSpeed = 20.0f;
    public float bulletLifetime = 5.0f; // sec before bullet is destroyed

    public AudioClip clip;


    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        source.PlayOneShot(clip);

        if (rb != null)
        {
            rb.linearVelocity = firepoint.forward * bulletSpeed;
        }

        // Destroy the bullet after a set time
        Destroy(bullet, bulletLifetime);
    }
}
