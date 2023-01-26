using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class CharacterInventoryComponent : MonoBehaviour
{
    [Header("Config:")] [SerializeField] private int m_maxSize = 12;
    [SerializeField] private List<InventoryItem> m_startingItem = new List<InventoryItem>();

    public Dictionary<ItemAsset, InventoryItem> ItemsDictionary => _itemDictionary;

    public int InventoryMaxSize => m_maxSize;

    #region Delegate Event

    public UnityAction<InventoryItem> OnDataChanged { get; set; }

    public UnityAction<InventoryItem> OnDataRemoved { get; set; }

    #endregion

    private readonly Dictionary<ItemAsset, InventoryItem> _itemDictionary = new ();

    #region Component Event Function

    private void Awake()
    {
        foreach (var item in m_startingItem)
        {
            if (_itemDictionary.Count >= m_maxSize)
                break;

            AddItem(item.ItemInfo, item.StackUnit);
        }
    }

    #endregion

    public bool HasItem(ItemAsset item) => _itemDictionary.ContainsKey(item);

    public void AddItem(InventoryItem inventoryItem) => AddItem(inventoryItem.ItemInfo, inventoryItem.StackUnit);
    
    public void AddItem(ItemAsset item, int units = 1)
    {
        
        // Does the inventory full ?
        if (_itemDictionary.Count >= m_maxSize) return;

        int unitsToAdd = Mathf.Clamp(units, 0, int.MaxValue);

        //If we have the item in the inventory & the item is stackable
        if (HasItem(item))
            _itemDictionary[item].AddStackUnit(unitsToAdd);
        else
            _itemDictionary.Add(item, new InventoryItem(item, unitsToAdd));
        
        OnDataChanged?.Invoke(_itemDictionary[item]);

    }

    public void RemoveItem(ItemAsset item, int units = 1)
    {
        //If we have the item in the inventory
        if (!HasItem(item)) return;

        var editItem = _itemDictionary[item];
            
        editItem.RemoveStackUnit(units);
        OnDataChanged.Invoke(editItem);
            
        if (editItem.StackUnit <= 0)
        {
            _itemDictionary.Remove(item);
            OnDataRemoved?.Invoke(editItem);
        }
    }

    private void LogInventory()
    {
        string inventoryString = null;
        foreach (var item in _itemDictionary)
        {
            inventoryString += "\n - " + item.Key.ItemName + ": " + item.Value.StackUnit;
        }

        Debug.Log(inventoryString);
    }
    
}
