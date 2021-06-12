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
        else if (currentItem.TypeWeapon == WeaponType.AutomaticRifle)
        {
            AutomaticRifleCategory(currentItem);
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

    private void AutomaticRifleCategory(Item currentItem)
    {
        if (InventoryItems[0] != new Item())
        {
            for (int j = 0; j < DropItems.Length; j++)
            {
                if (InventoryItems[0].ID == DropItems[j].ID)
                {
                    Instantiate(DropItems[j].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);

                    DisableWeapons();
                    InventoryItems[0] = currentItem;

                    for (int i = 0; i < ItemsInHand.Length; i++)
                    {
                        if (InventoryItems[0].ID == ItemsInHand[i].ID)
                        {
                            ItemsInHand[i].ItemPrefab.SetActive(true);
                            _inventoryUI.GetChild(0).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                            _inventoryUI.GetChild(0).gameObject.SetActive(true);
                            Destroy(currentItem.gameObject);
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            DisableWeapons();
            InventoryItems[0] = currentItem;

            for (int i = 0; i < ItemsInHand.Length; i++)
            {
                if (InventoryItems[0].ID == ItemsInHand[i].ID)
                {
                    _inventoryUI.GetChild(0).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(0).gameObject.SetActive(true);
                    ItemsInHand[i].ItemPrefab.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
    }

    private void RifleCategory(Item currentItem)
    {
        if (InventoryItems[1] != new Item())
        {
            for (int j = 0; j < DropItems.Length; j++)
            {
                if (InventoryItems[1].ID == DropItems[j].ID)
                {
                    Instantiate(DropItems[j].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);

                    DisableWeapons();
                    InventoryItems[1] = currentItem;

                    for (int i = 0; i < ItemsInHand.Length; i++)
                    {
                        if (InventoryItems[1].ID == ItemsInHand[i].ID)
                        {
                            ItemsInHand[i].ItemPrefab.SetActive(true);
                            _inventoryUI.GetChild(1).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                            _inventoryUI.GetChild(1).gameObject.SetActive(true);
                            Destroy(currentItem.gameObject);
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            DisableWeapons();
            InventoryItems[1] = currentItem;

            for (int i = 0; i < ItemsInHand.Length; i++)
            {
                if (InventoryItems[1].ID == ItemsInHand[i].ID)
                {
                    _inventoryUI.GetChild(1).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(1).gameObject.SetActive(true);
                    ItemsInHand[i].ItemPrefab.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
    }

    private void PistolCategory(Item currentItem)
    {
        if (InventoryItems[2] != new Item())
        {
            for (int j = 0; j < DropItems.Length; j++)
            {
                if (InventoryItems[2].ID == DropItems[j].ID)
                {
                    Instantiate(DropItems[j].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);

                    DisableWeapons();
                    InventoryItems[2] = currentItem;

                    for (int i = 0; i < ItemsInHand.Length; i++)
                    {
                        if (InventoryItems[2].ID == ItemsInHand[i].ID)
                        {
                            ItemsInHand[i].ItemPrefab.SetActive(true);
                            _inventoryUI.GetChild(2).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                            _inventoryUI.GetChild(2).gameObject.SetActive(true);
                            Destroy(currentItem.gameObject);
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            DisableWeapons();
            InventoryItems[2] = currentItem;

            for (int i = 0; i < ItemsInHand.Length; i++)
            {
                if (InventoryItems[2].ID == ItemsInHand[i].ID)
                {
                    _inventoryUI.GetChild(2).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(2).gameObject.SetActive(true);
                    ItemsInHand[i].ItemPrefab.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
    }


    private void GrenadeCategory(Item currentItem)
    {
        if (InventoryItems[3] != new Item())
        {
            for (int j = 0; j < DropItems.Length; j++)
            {
                if (InventoryItems[3].ID == DropItems[j].ID)
                {
                    Instantiate(DropItems[j].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);

                    DisableWeapons();
                    InventoryItems[3] = currentItem;
                        
                    for (int i = 0; i < ItemsInHand.Length; i++)
                    {
                        if (InventoryItems[3].ID == ItemsInHand[i].ID)
                        {
                            ItemsInHand[i].ItemPrefab.SetActive(true);
                            _inventoryUI.GetChild(3).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                            _inventoryUI.GetChild(3).gameObject.SetActive(true);
                            Destroy(currentItem.gameObject);
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            DisableWeapons();
            InventoryItems[3] = currentItem;

            for (int i = 0; i < ItemsInHand.Length; i++)
            {
                if (InventoryItems[3].ID == ItemsInHand[i].ID)
                {
                    _inventoryUI.GetChild(3).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(3).gameObject.SetActive(true);
                    ItemsInHand[i].ItemPrefab.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
    }

    private void RocketLauncherCategory(Item currentItem)
    {
        if (InventoryItems[4] != new Item())
        {
            for (int j = 0; j < DropItems.Length; j++)
            {
                if (InventoryItems[4].ID == DropItems[j].ID)
                {
                    Instantiate(DropItems[j].DropPrefab, currentItem.transform.position, currentItem.transform.rotation);

                    DisableWeapons();
                    InventoryItems[4] = currentItem;

                    for (int i = 0; i < ItemsInHand.Length; i++)
                    {
                        if (InventoryItems[4].ID == ItemsInHand[i].ID)
                        {
                            ItemsInHand[i].ItemPrefab.SetActive(true);
                            _inventoryUI.GetChild(4).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                            _inventoryUI.GetChild(4).gameObject.SetActive(true);
                            Destroy(currentItem.gameObject);
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            DisableWeapons();
            InventoryItems[4] = currentItem;

            for (int i = 0; i < ItemsInHand.Length; i++)
            {
                if (InventoryItems[4].ID == ItemsInHand[i].ID)
                {
                    _inventoryUI.GetChild(4).GetChild(0).GetComponent<Image>().sprite = currentItem.Icon;
                    _inventoryUI.GetChild(4).gameObject.SetActive(true);
                    ItemsInHand[i].ItemPrefab.SetActive(true);
                    Destroy(currentItem.gameObject);
                    return;
                }
            }
        }
    }

    private void DisableWeapons()
    {
        for (int i = 0; i < ItemsInHand.Length; i++)
        {
            if (ItemsInHand[i].ItemPrefab.activeSelf)
            {
                ItemsInHand[i].ItemPrefab.SetActive(false);
                break;
            }
        }
    }
}