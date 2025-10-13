using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movementInput;

    [SerializeField] private float speed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = GameManager.instance.playerSpeed;
    }

    void Update()
    {
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        movementInput.Normalize();

        if (Mathf.Abs(movementInput.x) > 0.1)
        {
            if (movementInput.x > 0.1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (movementInput.x < 0.1)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            animator.SetBool("walk_horizontal", true);
        }
        else
        {
            animator.SetBool("walk_horizontal", false);
        }

        if (movementInput.y > 0.1)
        {
            animator.SetBool("walk_up", true);
        }
        else
        {
            animator.SetBool("walk_up", false);
        }

        if (movementInput.y < -0.1)
        {
            animator.SetBool("walk_down", true);
        }
        else
        {
            animator.SetBool("walk_down", false);
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = movementInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
