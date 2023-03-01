using UnityEngine;

[RequireComponent(typeof(Animator), typeof(AudioSource))]
public class Apple : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private bool _isCollected;
    private int _collectAnimation = Animator.StringToHash("Collect");
    private int _baseAnimationLayer = 0;

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
            _animator.SetTrigger(_collectAnimation);
            Destroy(gameObject, _animator.GetCurrentAnimatorStateInfo(_baseAnimationLayer).length);
        }
    }
}
