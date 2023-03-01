using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SawChain : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _halfWidth;
    private Saw _saw;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _halfWidth = _spriteRenderer.size.x / 2;

        if (GetComponentsInChildren<Saw>().Length > 0)
        {
            _saw = GetComponentInChildren<Saw>();
            StartCoroutine(_saw.Move(_halfWidth));
        }
    }
}
