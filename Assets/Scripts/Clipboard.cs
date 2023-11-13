using UnityEngine;
using System.Collections;

public class Clipboard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.ClipboardCollected();
            StartCoroutine(goAway());
            GetComponent<AudioSource>().Play();
        }
    }
    private IEnumerator goAway()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}

