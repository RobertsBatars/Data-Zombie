using UnityEngine;

public class ShotgunShoot : Weapon
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 20f;
    [Space]
    [SerializeField] private int bulletCount = 5;
    [SerializeField] private float spreadAngle = 15f; // Total spread angle in degrees
    [Space(10)]
    [SerializeField] private PlayerInventory playerInventory;

    void Start()
    {

    }


    void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    /* Pistol Attack method for reference
     * GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        // Get 2D forward of the pistol based on rotation
        rb.linearVelocity = shootPoint.right * bulletSpeed; // In 2D, right is considered forward
        //Debug.Log(shootPoint.forward);
        //Debug.Log(rb.linearVelocity);
     */

    public override void Attack()
    {
        if (playerInventory.AmmoCount <=0)
            return;
        
        int ammoToConsume = Mathf.Min(bulletCount, playerInventory.AmmoCount);
        playerInventory.RemoveAmmo(ammoToConsume);

        for (int i = 0; i < ammoToConsume; i++)
        {
            // Calculate a random spread angle for each pellet
            float angle = Random.Range(-spreadAngle / 2, spreadAngle / 2);
            Quaternion spreadRotation = Quaternion.Euler(0, 0, angle);
            Vector3 pelletDirection = spreadRotation * shootPoint.right;
            GameObject newBullet = Instantiate(bullet, shootPoint.position, Quaternion.LookRotation(Vector3.forward, pelletDirection));
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = pelletDirection.normalized * bulletSpeed;
        }
    }
}
