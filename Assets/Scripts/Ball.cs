using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _startDirection;

    private Vector2 _startPosition;

    #endregion


    private void Awake()
    {
        _startPosition = transform.position;
    }


    #region Private methods

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, (Vector3) _startDirection + transform.position);
    }

    #endregion


    #region Public methods

    public void StartMove()
    {
        _rb.velocity = _startDirection;
    }

    public void MoveWithPad()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = Pad.Instance.PadPositionX;
        transform.position = currentPosition;
    }

    public void RestartPosition()
    {
        transform.position = _startPosition;
    }

    #endregion
}