using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class EndPoint : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private int _reachedTrigger = Animator.StringToHash("reached");
    private int _allApples;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _allApples = FindObjectsOfType<Apple>().Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AppleBasket basket))
        {
            if (basket.CollectedAppleCount == _allApples)
            {
                _audioSource.Play();
                _animator.SetTrigger(_reachedTrigger);
            }
        }
    }
}
