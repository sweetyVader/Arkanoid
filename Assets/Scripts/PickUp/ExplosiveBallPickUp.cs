using UnityEngine;

public class ExplosiveBallPickUp : PickUpBase
{
    [Header(nameof(ExplosiveBallPickUp))]
    [Range(0.5f, 1f)]
    [SerializeField] private float _radiusBallExplosive;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Sprite _explosiveSprite;
    [SerializeField] private SpriteRenderer _spriteBallRenderer;

    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().ChangeSprite(_explosiveSprite, _spriteBallRenderer);
        FindObjectOfType<Ball>().ExplosiveBall(_radiusBallExplosive, _layerMask);
    }
}