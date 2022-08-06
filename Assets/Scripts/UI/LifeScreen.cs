﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class LifeScreen : MonoBehaviour
{
    [SerializeField] private GameObject _lifePrefab;
    private int _numLifes;
    private List<GameObject> _allLifes;

    private float _bias = 1.5f;

    private void Awake()
    {
       
    }

    private void Start()
    {
        _numLifes = GameManager.Instance.Lifes;
        LifeChanged(_numLifes);
        
        GameManager.Instance.OnLifeChanged += LifeChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLifeChanged -= LifeChanged;
    }

    private void LifeChanged(int life)
    {
        foreach (GameObject lifeUI in GameObject.FindGameObjectsWithTag(Tags.Life))
            Destroy(lifeUI);
        
        Vector2 _startPosition = new Vector2(-11.5f, 6f);
        for (int i = 0; i < life; i++)
        {
            Vector2 _lifePosition = _startPosition;
            _lifePosition.x += _bias * i;
            Instantiate(_lifePrefab, _lifePosition, Quaternion.identity);
        }
    }
}