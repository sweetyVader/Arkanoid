using UnityEngine;

public class LoseZone : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Objects.Ball))
            GameManager.Instance.GameOver();
         //  FindObjectOfType<GameManager>().GameOver();
    }
}