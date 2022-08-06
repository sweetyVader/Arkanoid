using UnityEngine;

public class LifeChangePickUp : PickUpBase
{
    [Header(nameof(LifeChangePickUp))]
    [Range(-1f, 1f)]
    [SerializeField] private float _life;
    private int _numLife;

    protected override void ApplyEffect(Collision2D col)
    {
        if (_life > 0)
            _numLife = 1;

        else
            _numLife = -1;

        GameManager.Instance.ChangeLife(_numLife);
    }
}