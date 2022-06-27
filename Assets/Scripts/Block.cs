using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _numHit;
    [SerializeField] private Sprite[] _sprites;

    private void OnCollisionEnter2D(Collision2D col)
    {
        for (int i = 0; i <= _sprites.Length; i++)
        {
        }

        if (!string.IsNullOrEmpty(col.gameObject.name = "Bottom"))
            GameOver();
        Destroy(gameObject);
        Debug.Log($"Collision obj '{name}' with '{col.gameObject.name}'");
    }

    private void GameOver()
    {
    }
}