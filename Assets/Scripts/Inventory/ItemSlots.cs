using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlots : MonoBehaviour, IPointerClickHandler
{
    [Header("Item data")]
    [SerializeField] private string itemName;
    [SerializeField] private string itemDesc;
    [SerializeField] private Sprite itemSprite;
    public bool isFull { get; private set; }

    [Header("Item slot")]
    [SerializeField] private Image image;


    [Header("Item Description Data")]
    [SerializeField] private Image itemDescImage;
    [SerializeField] private TextMeshProUGUI itemDescName;
    [SerializeField] private TextMeshProUGUI itemDescFullText;
    //[SerializeField] private Image emptySprite;

    public GameObject selectedShader;
    public bool thisItemSelected;

    public void AddItem(Item1 item)
    {
        itemName = item.itemName;
        itemDesc = item.itemDescription;
        itemSprite = item.sprite;
        image.sprite = item.sprite;

        FillSlot();
    }


    private void FillSlot()
    {
        isFull = true;
        image.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left) 
        {
            OnLeftClick();
        }
    }

    private void OnLeftClick()
    {
        InventoryManager.instance.DeselecteShader();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        itemDescName.text = itemName;
        itemDescFullText.text = itemDesc;
        itemDescImage.sprite = itemSprite;
    }
}
