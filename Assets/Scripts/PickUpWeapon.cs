using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    private enum ItemType { Shotgun, Pistol, Knife, Ammo };
    [SerializeField] private ItemType itemType;
    [SerializeField] private int ammoAmount;

    private PlayerInventory playerInventory;
    void Start()
    {
        playerInventory = FindFirstObjectByType<PlayerInventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        switch (itemType)
        {
            case ItemType.Shotgun:
                playerInventory.EquipShotgun();
                break;
            case ItemType.Pistol:
                playerInventory.EquipPistol();
                break;
            case ItemType.Knife:
                playerInventory.EquipKnife();
                break;
            case ItemType.Ammo:
                ammoAmount = GameManager.instance.ammoPickupAmount;
                break;
        }
        playerInventory.AddAmmo(ammoAmount);
        Destroy(gameObject);
    }
}
