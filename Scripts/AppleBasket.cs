using UnityEngine;
using UnityEngine.Events;

public class AppleBasket : MonoBehaviour
{
    public event UnityAction AppleCollected
    {
        add => _appleCollected.AddListener(value);
        remove => _appleCollected.RemoveListener(value);
    }

    private UnityEvent _appleCollected = new UnityEvent();

    public int CollectedAppleCount { get; private set; }

    public void AddApple()
    {
        CollectedAppleCount++;
        _appleCollected?.Invoke();
    }
}
