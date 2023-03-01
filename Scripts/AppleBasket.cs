using UnityEngine;
using UnityEngine.Events;

public class AppleBasket : MonoBehaviour
{
    public event UnityAction AppleCollected
    {
        add => _collectedApple.AddListener(value);
        remove => _collectedApple.RemoveListener(value);
    }

    private UnityEvent _collectedApple = new UnityEvent();

    public int CollectedAppleCount { get; private set; }

    public void AddApple()
    {
        CollectedAppleCount++;
        _collectedApple?.Invoke();
    }
}
