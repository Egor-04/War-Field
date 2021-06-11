using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _playerCamera;

    [Header("Ray Length")]
    [SerializeField] private float _rayLength = 15f;

    [Header("Buttons")]
    public KeyCode _takeItem = KeyCode.E;

    [Header("Inventory UI")]
    [SerializeField] Transform _inventoryUI;

    [Header("Inventory")]
    public List<Item> InventoryItems;

    [Header("Items In Hand")]
    public ItemInHand[] ItemsInHand;

    public class ItemInHand
    {
        public int ID;
        public GameObject ItemPrefab;
    }

    private void Start()
    {
        InventoryItems = new List<Item>();

        for (int i = 0; i < InventoryItems.Count; i++)
        {
            InventoryItems.Add(new Item());
        }
    }

    private void Update()
    {
        Ray ray = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayLength))
        {
            if (hit.collider.GetComponent<Item>())
            {
                Item currentItem = hit.collider.GetComponent<Item>();
                AddItem(currentItem);
            }
        }
    }

    private void AddItem(Item currentItem)
    {
        if (currentItem.TypeWeapon == WeaponType.Pistol)
        {
            PistolCategory(currentItem);
        }
        else if (currentItem.TypeWeapon == WeaponType.Rifle)
        {
            RifleCategory(currentItem);
        }
        else if (currentItem.TypeWeapon == WeaponType.Grenade)
        {
            GrenadeCategory(currentItem);
        }
        else if (currentItem.TypeWeapon == WeaponType.RocketLauncher)
        {
            RocketLauncherCategory(currentItem);
        }
    }

    private void PistolCategory(Item currentItem)
    {
        if (InventoryItems[0] != null)
        {
            Instantiate(InventoryItems[0].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);
            InventoryItems[0] = currentItem;
            _inventoryUI.GetChild(0).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(0).gameObject.SetActive(true);
            Destroy(currentItem);
        }
        else
        {
            InventoryItems[0] = currentItem;
            _inventoryUI.GetChild(0).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(0).gameObject.SetActive(true);
            return;
        }
    }

    private void RifleCategory(Item currentItem)
    {
        if (InventoryItems[1] != null)
        {
            Instantiate(InventoryItems[1].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);
            InventoryItems[1] = currentItem;
            _inventoryUI.GetChild(1).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(1).gameObject.SetActive(true);
            Destroy(currentItem);
        }
        else
        {
            InventoryItems[1] = currentItem;
            _inventoryUI.GetChild(1).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(1).gameObject.SetActive(true);
            return;
        }
    }

    private void GrenadeCategory(Item currentItem)
    {
        if (InventoryItems[2] != null)
        {
            Instantiate(InventoryItems[2].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);
            InventoryItems[2] = currentItem;
            _inventoryUI.GetChild(2).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(2).gameObject.SetActive(true);
            Destroy(currentItem);
        }
        else
        {
            InventoryItems[2] = currentItem;
            _inventoryUI.GetChild(2).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(2).gameObject.SetActive(true);
            return;
        }

    }

    private void RocketLauncherCategory(Item currentItem)
    {
        if (InventoryItems[3] != null)
        {
            Instantiate(InventoryItems[3].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);
            InventoryItems[3] = currentItem;
            _inventoryUI.GetChild(3).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(3).gameObject.SetActive(true);
            Destroy(currentItem);
        }
        else
        {
            InventoryItems[3] = currentItem;
            _inventoryUI.GetChild(3).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(3).gameObject.SetActive(true);
            return;
        }
    }
}