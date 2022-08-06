using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [Header("Block")]
    [SerializeField] private int _numHit;
    [SerializeField] private int _hp;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Pick Up")]
    [SerializeField] private GameObject _pickUpPrefab;

    [Range(0f, 1f)]
    [SerializeField] private float _pickUpSpawnChance;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.Ball))
            return;
        _hp--;

        if (_hp <= 0)
        {
            SpawnPickUp();
            Destroy(gameObject);
            ScoreManager.Instance.ChangeScore(_numHit);
        }
        else
        {
            SetSprite();
        }
    }

    #endregion


    #region Private methods

    private void SpawnPickUp()
    {
        if (_pickUpPrefab == null)
            return;

        float random = Random.Range(0f, 1f);
        if (random <= _pickUpSpawnChance)
        {
            Instantiate(_pickUpPrefab, transform.position, Quaternion.identity);
        }
    }

    private void SetSprite()
    {
        _spriteRenderer.sprite = _sprites[_sprites.Length - _hp];
    }

    #endregion
}