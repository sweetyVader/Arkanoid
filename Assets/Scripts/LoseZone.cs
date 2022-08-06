using UnityEngine;

public class LoseZone : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Ball))
        {
            GameManager.Instance.GameOver();
        } 
        else
        {
            Destroy(col.gameObject);
        }
    }
}