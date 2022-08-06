using UnityEngine;

public class BallSizeChangePickUp : PickUpBase
{
    [Header(nameof(BallSizeChangePickUp))]
    [Range(0.5f, 2f)]
    [SerializeField] private float _size;

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ChangeSize(_size);
    }
}