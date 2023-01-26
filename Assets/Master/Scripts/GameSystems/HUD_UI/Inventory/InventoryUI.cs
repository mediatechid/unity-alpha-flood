using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryUI : BaseHUD
{
    [Space] 
    [Header("Required Component")] 
    [SerializeField] private GridLayoutGroup m_slotGridLayout;
    [SerializeField] private CharacterInventoryComponent m_targetInventory;

    [Header("Slot")] 
    [SerializeField] private GameObject m_slotPrefab;

    private List<InventorySlotUI> _slotList;

    protected override void InitHUD()
    {
        base.InitHUD();
        
        if (!m_slotGridLayout)
            m_slotGridLayout = GetComponentInChildren<GridLayoutGroup>();

        if (!m_targetInventory)
            Debug.LogError("Target Inventory not found");
        
        InitLayout();

        VisualizeAllData();

        m_targetInventory.OnDataChanged += VisualizeData;
        m_targetInventory.OnDataRemoved += RemoveVisualData;
    }

    private void InitLayout()
    {
        _slotList = new List<InventorySlotUI>(m_targetInventory.InventoryMaxSize);

        for (int i = 0; i < m_targetInventory.InventoryMaxSize; i++)
        {
            Instantiate(m_slotPrefab, m_slotGridLayout.gameObject.transform);
        }

        _slotList.AddRange(m_slotGridLayout.GetComponentsInChildren<InventorySlotUI>());

    }

    public void VisualizeAllData()
    {

        var slotIndex = 0;
        foreach (var inventoryItem in m_targetInventory.ItemsDictionary.Values)
        {
            _slotList[slotIndex].SlotVisualData = inventoryItem;
            slotIndex++;
        }

    }

    public void VisualizeData(InventoryItem item)
    {
        InventorySlotUI slotToFill = null;

        bool isStackable = item.ItemInfo.IsStackable;

        if (isStackable)
        {
            foreach (var slot in _slotList)
            {
                if (slot.SlotVisualData != null)
                {
                    if (slot.SlotVisualData.ItemInfo == item.ItemInfo)
                    {
                        slotToFill = slot;
                        break;
                    }
                }
            }
        }

        if (!isStackable || !slotToFill)
        {
            foreach (var slot in _slotList)
            {
                if (slot.SlotVisualData == null)
                {
                    slotToFill = slot;
                    break;
                }
            }
        }

        slotToFill.SlotVisualData = item;
    }

    public void RemoveVisualData(InventoryItem removeItem)
    {
        foreach (var slot in _slotList)
        {
            if (slot.SlotVisualData.ItemInfo == removeItem.ItemInfo)
            {
                slot.SlotVisualData = null;
            }
        }
    }
}
