using UnityEngine;

public class BallSpeedChangePickUp : PickUpBase
{
    [Header(nameof(BallSpeedChangePickUp))]
    [SerializeField] private float _speedMultiplier;

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ChangeSpeed(_speedMultiplier);
    }
}