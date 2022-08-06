using System;
using UnityEngine;

public class Pad : SingletonMonoBehaviour<Pad>
{

    #region Variables

    private Ball _ball;

    #endregion
    #region Properties

    public float PadPositionX { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        if (PauseManager.Instance.IsPaused)
            return;

        if (GameManager.Instance.NeedAutoPlay)

        {
            MoveWithBall();
        }
        else
        {
            MoveWithMouse();
        }
        Vector3 currentPosition = transform.position;
        PadPositionX = currentPosition.x;
    }

    #endregion


    #region Private methods

    private void MoveWithBall()
    {
        Vector3 ballPosition = _ball.transform.position;
        Vector3 currentPosition = transform.position;
        currentPosition.x = ballPosition.x;

        transform.position = currentPosition;
    }

    private void MoveWithMouse()
    {
        Vector3 mousePositionInPixels = Input.mousePosition;
        Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
        Vector3 currentPosition = transform.position;
        currentPosition.x = mousePositionInUnits.x;

        transform.position = currentPosition;

       
    }

    #endregion


    public void ChangeSize(float size)
    {
        Vector3 currentPadScale = transform.localScale;
        currentPadScale.x = size;
        transform.localScale = currentPadScale;
    }
}