using UnityEngine;

public class ExplosiveBlock : Block
{
    #region Variables

    [Header(nameof(ExplosiveBlock))]
    [SerializeField] private float _explosiveRadius;
    [SerializeField] private LayerMask _layerMask;

    #endregion


    #region Unitu lifecycle

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosiveRadius);
    }

    #endregion


    #region Public methods

    public override void DestroyBlock()
    {
        base.DestroyBlock();

        Explode();
    }

    #endregion


    #region Private methods

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosiveRadius, _layerMask);

        foreach (Collider2D collider in colliders)
        {
            Block blockToExplode = collider.GetComponent<Block>();
            blockToExplode.HitToBlock();
        }
    }

    #endregion
}