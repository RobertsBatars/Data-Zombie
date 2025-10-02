using UnityEngine;

public class KnifeAttack : Weapon
{
    private Animator animator;
    private RotatePointMouse rotatePointMouse;
    private Camera mainCamera;
    [HideInInspector] public bool animationFinishedTrigger = false;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackConeAngle = 60f;
    [SerializeField] private int attackDamage = 15;
    void Start()
    {
        animator = GetComponent<Animator>();
        rotatePointMouse = GetComponent<RotatePointMouse>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (animationFinishedTrigger)
        {
            DisableAnimator();
            animationFinishedTrigger = false;
        }
    }

    public override void Attack()
    {
        if (animator.enabled)
            return;

        animator.enabled = true;
        animator.SetTrigger("knife_attack");

        // Add 90 degrees to the knife rotation on the Z axis for the attack animation
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
        rotatePointMouse.enabled = false;

        // Detect enemies in range of the knife
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Enemy"));
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        foreach (Collider2D enemy in hitEnemies)
        {
            Vector2 directionToEnemy = (enemy.transform.position - transform.position).normalized;
            Vector2 directionToMouse = (mousePosition - (Vector2)transform.position).normalized;
            float angleToEnemy = Vector2.Angle(directionToMouse, directionToEnemy);

            if (angleToEnemy < attackConeAngle / 2)
            {
                enemy.GetComponent<EnemyHealth>().DamageEnemy(attackDamage);
            }
        }
    }

    public void DisableAnimator()
    {
        animator.enabled = false;
        rotatePointMouse.enabled = true;
    }
}
