using UnityEngine;

public class Clipboard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.ClipboardCollected();
            gameObject.SetActive(false);
        }
    }
}

