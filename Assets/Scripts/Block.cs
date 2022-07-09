using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _numHit;
    [SerializeField] private int _hp;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    #endregion


    #region Private methods

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        _hp--;

        if (_hp <= 0)
        {
            Destroy(gameObject);
           // GameManager.Instance.Counter(_numHit);
           Debug.Log($"{_numHit}");
           ScoreManager.Instance.Counter(_numHit);
        }
        else
        {
            SetSprite();
        }
    }

    private void SetSprite()
    {
        _spriteRenderer.sprite = _sprites[_sprites.Length - _hp];
    }

    #endregion
}