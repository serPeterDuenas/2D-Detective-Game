using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    [SerializeField] private int X_START;
    [SerializeField] private int X_SPACE_BETWEEN_ITEMS;
    [SerializeField] private int Y_SPACE_BETWEEN_ITEMS;
    [SerializeField] private int NUMBER_OF_COLUMNS;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.instance.endOfDialogue) 
        {
            Debug.Log(DialogueManager.instance.endOfDialogue);
            UpdateDisplay(); 
            if(DialogueManager.instance.endOfDialogue)
            {
                DialogueManager.instance.endOfDialogue = !DialogueManager.instance.endOfDialogue;
            }
        }
        else
            return;
       
    }


    // Takes the item prefabs contained inside of InventoryObject and populates them 
    // To the UI
    private void CreateDisplay()
    {
        for (int q = 0; q < inventory.Container.Count; q++)
        {
            var obj = Instantiate(inventory.Container[q].item.prefab,
                Vector3.zero, Quaternion.identity, transform);

            obj.GetComponent<RectTransform>().localPosition = GetPosition(q);

            itemsDisplayed.Add(inventory.Container[q], obj);
        }
    }


    // Takes values from fields, and gets a Vector3 position
    // per the inventory index that is looped through, 
    private Vector3 GetPosition(int i)
    {
        //(X_START + (X_SPACE_BETWEEN_ITEMS * (i % NUMBER_OF_COLUMNS))

        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEMS * i),
            -Y_SPACE_BETWEEN_ITEMS * (i/NUMBER_OF_COLUMNS),
            0f);
    }


    private void UpdateDisplay()
    {

        // Loop through inventory and check for if there are Slot keys, na
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            Debug.Log(i);
            // If in the dictionary there is already an InventorySlot, then do nothing since Im not
            // putting text on screen
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                Debug.Log("Item already in inventory");
            }
            // Otherwise, instantiate the Image object onto the UI panel, as done also in CreateDisplay
            else
            {
                Debug.Log("Creating Image for new item obtained");
                var obj = Instantiate(inventory.Container[i].item.prefab,
                Vector3.zero, Quaternion.identity, transform);

                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

                // If new item, add to the dictionary the container indexed and the Image object 
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
