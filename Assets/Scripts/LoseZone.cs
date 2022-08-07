using UnityEngine;

public class LoseZone : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Ball))
        {
            if (GameObject.FindGameObjectsWithTag(Tags.Ball).Length == 1) 
                GameManager.Instance.GameOver();
            else
                Destroy(col.gameObject);
        }
        else
        {
            Destroy(col.gameObject);
        }
    }
}