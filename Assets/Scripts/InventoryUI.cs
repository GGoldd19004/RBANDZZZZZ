using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI clipboardText;

    // Start is called before the first frame update
    void Start()
    {
        clipboardText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateClipboardText(PlayerInventory playerInventory)
    {
        clipboardText.text = playerInventory.NumberOfClipboards.ToString();
    }
}
