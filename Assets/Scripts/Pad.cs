using UnityEngine;

public class Pad : SingletonMonoBehaviour<Pad>
{
    #region Properties

    public float PadPositionX { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (PauseManager.Instance.IsPaused)
            return;
        Vector3 mousePositionInPixels = Input.mousePosition;
        Vector3 mousePositionInUnits = Camera.main.ScreenToWorldPoint(mousePositionInPixels);
        Vector3 currentPosition = transform.position;
        currentPosition.x = mousePositionInUnits.x;

        transform.position = currentPosition;

        PadPositionX = currentPosition.x;
    }

    #endregion
}