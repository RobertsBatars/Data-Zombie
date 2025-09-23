using UnityEngine;

public class KnifeAttack : Weapon
{
    private Animator animator;
    [SerializeField] private bool disableAnimatorTrigger = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gameObject.activeInHierarchy && Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        if (disableAnimatorTrigger)
        {
            DisableAnimator();
            disableAnimatorTrigger = false;
        }
    }

    public override void Attack()
    {
        animator.enabled = true;
        animator.SetTrigger("knife_attack");
    }

    public void DisableAnimator()
    {
        animator.enabled = false;
    }
}
