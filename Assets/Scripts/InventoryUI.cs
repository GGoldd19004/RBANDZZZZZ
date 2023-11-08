using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI clipboardText;
    private SpawnCollectablesScript bScript;

    // Start is called before the first frame update
    void Start()
    {
        clipboardText = GetComponent<TextMeshProUGUI>();

        GameObject g = GameObject.Find("SpawnCollectables");
        bScript = g.GetComponent<SpawnCollectablesScript>();

        clipboardText.text = "0/" + bScript.amountOfCollectables.ToString();
    }

    public void UpdateClipboardText(PlayerInventory playerInventory)
    {
        int NumOfCollected = playerInventory.NumberOfClipboards;
        int NumOfNeededCollected = bScript.amountOfCollectables;

        if (NumOfCollected == NumOfNeededCollected)
        {
            SceneManager.LoadScene(2);
        }

        clipboardText.text = NumOfCollected.ToString() + "/" + NumOfNeededCollected.ToString();
    }
}
