using System.Collections;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private float _duration;

    private bool _isMoving = true;
    private bool _isMovingLeft;
    private float _runningTime;

    public IEnumerator Move(float distation)
    {
        while (_isMoving)
        {
            _runningTime = Mathf.MoveTowards(_runningTime, _isMovingLeft ? -_duration : _duration, Time.deltaTime);

            float step = _runningTime / _duration;
            transform.localPosition = new Vector2(Mathf.Lerp(-distation, distation, step), 0);

            if (transform.localPosition.x == distation || transform.localPosition.x == -distation)
                _isMovingLeft = _isMovingLeft == false;

            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.RestartGame();
    }
}