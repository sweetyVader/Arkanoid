using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _startDirection;
    [SerializeField] private Pad _pad;
    
    #endregion


    #region Unity lifecycle

   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position,  (Vector3)_startDirection + transform.position);
    }

    #endregion
    #region Public methods

    public void StartMove()
    {
        
        //Vector3 eulers = ball.transform.eulerAngles.x, Random.Range(-45f, 45f), ball.eulerAngles.z;
        //ball.MoveRotation(eulers);
        _rb.velocity = _startDirection;
    }

    #endregion


    public void MoveWithPad()
    {
        Vector3 padPosition = _pad.transform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = padPosition.x;
        transform.position = currentPosition;
    }

    
   

}