using System;
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

    [Header("Drop Items")]
    public DropItem[] DropItems;

    [Serializable]
    public class ItemInHand
    {
        public int ID;
        public GameObject ItemPrefab;
    }

    [Serializable]
    public class DropItem
    {
        public int ID;
        public GameObject DropPrefab;
    }

    private void Start()
    {
        InventoryItems = new List<Item>();

        for (int i = 0; i < _inventoryUI.childCount; i++)
        {
            InventoryItems.Add(new Item());
        }
    }

    private void Update()
    {
        Debug.DrawRay(_playerCamera.transform.position, _playerCamera.transform.forward * _rayLength, Color.green);

        if (Input.GetKeyDown(_takeItem))
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
        if (InventoryItems[0] != new Item())
        {
            for (int i = 0; i < DropItems.Length; i++)
            {
                if (InventoryItems[0].ID == DropItems[i].ID)
                {
                    Instantiate(DropItems[i].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);
                    InventoryItems[0] = currentItem;
                    _inventoryUI.GetChild(0).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(0).gameObject.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
        else
        {
            InventoryItems[0] = currentItem;
            _inventoryUI.GetChild(0).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(0).gameObject.SetActive(true);
            Destroy(currentItem.gameObject);
            return;
        }
    }

    private void RifleCategory(Item currentItem)
    {
        if (InventoryItems[1] != new Item())
        {
            for (int i = 0; i < DropItems.Length; i++)
            {
                if (InventoryItems[1].ID == DropItems[i].ID)
                {
                    Instantiate(DropItems[i].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);

                    InventoryItems[1] = currentItem;
                    _inventoryUI.GetChild(1).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(1).gameObject.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
        else
        {
            InventoryItems[1] = currentItem;
            _inventoryUI.GetChild(1).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(1).gameObject.SetActive(true);
            Destroy(currentItem.gameObject);
            return;
        }
    }

    private void GrenadeCategory(Item currentItem)
    {
        if (InventoryItems[2] != new Item())
        {
            for (int i = 0; i < DropItems.Length; i++)
            {
                if (InventoryItems[2].ID == DropItems[i].ID)
                {
                    Instantiate(DropItems[i].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);

                    InventoryItems[2] = currentItem;
                    _inventoryUI.GetChild(2).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(2).gameObject.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
        else
        {
            InventoryItems[2] = currentItem;
            _inventoryUI.GetChild(2).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(2).gameObject.SetActive(true);
            Destroy(currentItem.gameObject);
            return;
        }

    }

    private void RocketLauncherCategory(Item currentItem)
    {
        if (InventoryItems[3] != new Item())
        {
            for (int i = 0; i < DropItems.Length; i++)
            {
                if (InventoryItems[3].ID == DropItems[i].ID)
                {
                    Instantiate(DropItems[i].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);

                    InventoryItems[3] = currentItem;
                    _inventoryUI.GetChild(3).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(3).gameObject.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
        else
        {
            InventoryItems[3] = currentItem;
            _inventoryUI.GetChild(3).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
            _inventoryUI.GetChild(3).gameObject.SetActive(true);
            Destroy(currentItem.gameObject);
            return;
        }
    }
}