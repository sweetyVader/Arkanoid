using UnityEngine;

public abstract class PickUpBase : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioClip _audioClip;
    
    [Header("Score")]
    [SerializeField] private int _pickUpScore;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.Pad))
            return;
        AudioPlayer.Instance.PlaySound(_audioClip);
        ScoreManager.Instance.ChangeScore(_pickUpScore);
        ApplyEffect(col);
        Destroy(gameObject);
    }

    protected abstract void ApplyEffect(Collision2D col);
}