using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item Object")]
public class ItemAsset : ScriptableObject
{
    [SerializeField] private ItemData m_itemData;

    public ItemData ItemData => m_itemData;
    public string ItemName => m_itemData.ItemName;
    public string ItemDescription => m_itemData.ItemDescription;
    public Sprite ItemIcon => m_itemData.ItemItemIcon;
    public bool IsStackable => m_itemData.IsStackable;
    public int ScorePerItem => m_itemData.ScorePerItem;
    public EPriorityState ItemPriorityState => m_itemData.ItemPriorityState;
    public int ItemPriority => m_itemData.ItemPriority;
    public override bool Equals(object other)
    {
        if (other is ItemAsset otherItem)
        {
            return ItemName == otherItem.ItemName;
        }
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ItemName);
    }

    public bool ComparePriority(ItemAsset other)
    {
        if (ItemPriorityState == other.ItemPriorityState)
            return ItemPriority >= other.ItemPriority;
        
        return ItemPriorityState > other.ItemPriorityState;
        
    }
}
