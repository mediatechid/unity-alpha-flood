using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPriorityItemsList", menuName = "Items/Items list")]
public class ItemList : ScriptableObject
{
    [SerializeField] private List<ItemAsset> m_itemsList = new List<ItemAsset>();

    public List<ItemAsset> ItemsList => m_itemsList;
    
    public bool HasItem(ItemAsset itemAsset) => m_itemsList.Contains(itemAsset);

    public ItemAsset GetTopPriorityItem()
    {
        ItemAsset cacheItem = null;

        foreach (var itemIteration in m_itemsList)
        {
            if (!cacheItem)
                cacheItem = itemIteration;
            else
                if (itemIteration.ComparePriority(cacheItem))
                    cacheItem = itemIteration;
        }

        return cacheItem;
    }

    public ItemAsset GetLowestPriorityItem()
    {
        ItemAsset cacheItem = null;

        foreach (var itemIteration in m_itemsList)
        {
            if (!cacheItem)
                cacheItem = itemIteration;
            else
            if (!itemIteration.ComparePriority(cacheItem))
                cacheItem = itemIteration;
        }

        return cacheItem;
    }

    
    
}
