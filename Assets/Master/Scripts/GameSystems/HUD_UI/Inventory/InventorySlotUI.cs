using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public sealed class InventorySlotUI : BaseHUD
{
    [Space]
    [Header("Required Component")]
    [SerializeField] private Image m_slotIcon;
    [SerializeField] private TextMeshProUGUI m_dataStackUnits;

    public InventoryItem SlotVisualData 
    {
        get => _visualData; 
        set 
        {
            _visualData = value;
            ProjectData();
        }
    }

    private InventoryItem _visualData;

    protected override void InitHUD() => ProjectData();

    private void ProjectData()
    {

        if (_visualData != null)
        {
            m_slotIcon.enabled = true;
            m_slotIcon.sprite = _visualData.ItemInfo.ItemIcon;

            if (_visualData.IsStackable)
            {
                m_dataStackUnits.enabled = true;
                m_dataStackUnits.text = _visualData.StackUnit.ToString();
            }
        }
        else
        {
            m_slotIcon.enabled = false; 
            m_dataStackUnits.enabled = false;
        }
    }
}
