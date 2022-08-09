using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables

    [Header("Block")]
    [SerializeField] private int _numHit;
    [SerializeField] private int _hp;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Pick Up")]
    //[SerializeField] private GameObject _pickUpPrefab;
    [Range(0f, 1f)]
    [SerializeField] private float _pickUpSpawnChance;
    [SerializeField] private PickUpInfo[] _pickUpInfoArray;

    [Header("Music")]
    [SerializeField] private AudioClip _audioClip;

    #endregion


    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.Ball))
            return;
        HitToBlock();
    }

    #endregion


    #region Public methods

    public virtual void HitToBlock()
    {
        _hp--;

        if (_hp <= 0)
        {
            DestroyBlock();
        }
        else
            SetSprite();
    }

    public virtual void DestroyBlock()
    {
        AudioPlayer.Instance.PlaySound(_audioClip);
        SpawnPickUp();
        Destroy(gameObject);
        ScoreManager.Instance.ChangeScore(_numHit);
    }

    #endregion


    #region Private methods

    private void SpawnPickUp()
    {
        if (_pickUpInfoArray == null || _pickUpInfoArray.Length == 0)
            return;

        float random = Random.Range(0f, 1f);
        if (random > _pickUpSpawnChance)
            return;
        int chanceSum = 0;

        foreach (PickUpInfo pickUpInfo in _pickUpInfoArray)
            chanceSum += pickUpInfo.SpawnChance;

        int randomChance = Random.Range(0, chanceSum);
        int currentChance = 0;
        int currentIndex = 0;

        for (int i = 0; i < _pickUpInfoArray.Length; i++)
        {
            PickUpInfo pickUpInfo = _pickUpInfoArray[i];
            currentChance += pickUpInfo.SpawnChance;

            if (currentChance >= randomChance)
            {
                currentIndex = i;
                break;
            }
        }

        PickUpBase pickUpPrefab = _pickUpInfoArray[currentIndex].PickUpPrefab;
        Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
    }

    private void SetSprite()
    {
        _spriteRenderer.sprite = _sprites[_sprites.Length - _hp];
    }

    #endregion
}