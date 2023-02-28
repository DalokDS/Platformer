using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Apple : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private bool _isCollected;
    private int collectAnimation = Animator.StringToHash("Collect");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AppleBasket basket) && _isCollected == false)
        {
            basket.AddApple();
            _isCollected = true;
            _audioSource.Play();
            _animator.SetTrigger(collectAnimation);
        }
    }

    private void Collect()
    {
        Destroy(gameObject);
    }
}
