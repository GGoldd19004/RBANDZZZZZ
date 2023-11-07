using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfClipboards { get; private set; }

    public UnityEvent<PlayerInventory> OnClipboardCollected;

    public void ClipboardCollected()
    {
        NumberOfClipboards++;
        OnClipboardCollected.Invoke(this);
    }
}
