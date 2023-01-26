using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    [SerializeField] private ItemAsset m_itemAsset;
    [SerializeField] private int m_itemStackUnit;

    public ItemAsset ItemInfo => m_itemAsset;
    public bool IsStackable => m_itemAsset.IsStackable;
    public int StackUnit => m_itemStackUnit;

    public InventoryItem(ItemAsset data, int unit)
    {
        m_itemAsset = data; 
        m_itemStackUnit = unit;
    }

    public void AddStackUnit(int unitToAdd = 1) 
    {
        m_itemStackUnit += unitToAdd;
        m_itemStackUnit = Mathf.Clamp(m_itemStackUnit, 0, int.MaxValue);
    }

    public void RemoveStackUnit(int unitToRemove = 1) 
    {
        m_itemStackUnit -= unitToRemove;
    }
        
}