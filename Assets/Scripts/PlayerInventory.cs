using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int ammoCount = 0;
    [Space(10)]
    [SerializeField] private GameObject pistolObject;
    [SerializeField] private GameObject shotgunObject;
    [SerializeField] private GameObject knifeObject;
    public int AmmoCount { get { return ammoCount; } }

    public void AddAmmo(int amount)
    {
        ammoCount += amount;
    }

    public void RemoveAmmo(int amount) {
        ammoCount -= amount;
    }

    public void EquipPistol()
    {
        pistolObject.SetActive(true);
        shotgunObject.SetActive(false);
        knifeObject.SetActive(false);
    }
    public void EquipShotgun()
    {
        pistolObject.SetActive(false);
        shotgunObject.SetActive(true);
        knifeObject.SetActive(false);
    }
    public void EquipKnife()
    {
        pistolObject.SetActive(false);
        shotgunObject.SetActive(false);
        knifeObject.SetActive(true);
    }
}
