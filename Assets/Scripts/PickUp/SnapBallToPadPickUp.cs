using UnityEngine;

public class SnapBallToPadPickUp : PickUpBase
{
    protected override void ApplyEffect(Collision2D col)
    {
        FindObjectOfType<Ball>().SnapBallToPad();
        
    }
}