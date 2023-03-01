using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CollectedAppleCountShower : MonoBehaviour
{
    [SerializeField] private AppleBasket _appleBasket;

    private Text _text;
    private int _allApples;

    private void Awake()
    {
        _text = GetComponent<Text>();
        _allApples = FindObjectsOfType<Apple>().Length;
        _text.text = $"{_appleBasket.CollectedAppleCount} / {_allApples}";
    }

    private void OnEnable()
    {
        _appleBasket.AppleCollected += OnAppleCollected;
    }

    private void OnDisable()
    {
        _appleBasket.AppleCollected -= OnAppleCollected;
    }

    private void OnAppleCollected()
    {
        _text.text = $"{_appleBasket.CollectedAppleCount} / {_allApples}";
    }
}
