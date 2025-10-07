using UnityEngine;

public class PistolShoot : Weapon
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 20f;
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

    public override void Attack()
    {
        if (playerInventory.AmmoCount <= 0)
            return;
        playerInventory.RemoveAmmo(1);
        GameObject newBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        // Get 2D forward of the pistol based on rotation
        rb.linearVelocity = shootPoint.right * bulletSpeed; // In 2D, right is considered forward
        //Debug.Log(shootPoint.forward);
        //Debug.Log(rb.linearVelocity);
    }
}
