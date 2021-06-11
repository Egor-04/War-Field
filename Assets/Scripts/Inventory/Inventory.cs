using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
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
        
    }
}
