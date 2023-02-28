using UnityEngine;
using UnityEngine.Events;

public class AppleBasket : MonoBehaviour
{
    private UnityEvent _collectedApple = new UnityEvent();

    public event UnityAction CollectedApple
    {
        add => _collectedApple.AddListener(value);
        remove => _collectedApple.RemoveListener(value);
    }

    public int CollectedAppleCount { get; private set; }

    public void AddApple()
    {
        CollectedAppleCount++;
        _collectedApple?.Invoke();
    }
}
