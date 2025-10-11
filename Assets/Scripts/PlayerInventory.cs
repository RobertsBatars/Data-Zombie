using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int ammoCount = 0;
    [Space(10)]
    [SerializeField] private GameObject pistolObject;
    [SerializeField] private GameObject shotgunObject;
    [SerializeField] private GameObject knifeObject;
    [Space(10)]
    [InspectorLabel("UI Elements")]
    [SerializeField] private TMP_Text ammoText;

    private string ammoUIPrefix = "Ammo: ";
    public int AmmoCount { get { return ammoCount; } }

    private void Start()
    {
        ammoText.text = ammoUIPrefix + "0";
    }
    public void AddAmmo(int amount)
    {
        ammoCount += amount;
        ammoText.text = ammoUIPrefix + ammoCount.ToString();
        GameManager.instance.totalAmmoCollected += amount;
    }

    public void RemoveAmmo(int amount) {
        ammoCount -= amount;
        ammoText.text = ammoUIPrefix + ammoCount.ToString();
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
