using UnityEngine;

public class RotatePointMouse : MonoBehaviour
{
    [SerializeField] private float angleOffset = 0;
    [SerializeField] private Transform tipOfTheGun;

    Vector2 mousePosition;
    Vector2 gunPosition;
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        // get mouse position
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        // get angle between mouse position and player position
        gunPosition = tipOfTheGun.position;
        Vector2 direction = mousePosition - gunPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // rotate the weapon
        transform.rotation = Quaternion.Euler(0, 0, angle + angleOffset);
    }
}
