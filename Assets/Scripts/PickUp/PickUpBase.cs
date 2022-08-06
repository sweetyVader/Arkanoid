using UnityEngine;

public abstract class PickUpBase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.Pad))
            return;
        ApplyEffect(col);
        Destroy(gameObject);
    }

    protected abstract void ApplyEffect(Collision2D col);
}