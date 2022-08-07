using UnityEngine;

public class DoubleBallPickUp : PickUpBase
{
    protected override void ApplyEffect(Collision2D col)
    {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag(Tags.Ball))
           FindObjectOfType<Ball>().DoubleBall(ball);
    }
}