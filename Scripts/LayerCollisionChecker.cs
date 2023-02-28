using UnityEngine;

public class LayerCollisionChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector2 _checkSize;
    [SerializeField] private float _checkAngle;

    public bool IsCollisioned { get; private set; }

    private void Update()
    {
        IsCollisioned = Physics2D.OverlapBox(transform.position, _checkSize, _checkAngle, _layerMask);
    }
}
