using UnityEngine;

public class PadSizeChangePickUp : PickUpBase
{
    [Header(nameof(PadSizeChangePickUp))]
    [Range(0.5f, 2f)]
    [SerializeField] private float _size;

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Pad>().ChangeSize(_size);
    }
}