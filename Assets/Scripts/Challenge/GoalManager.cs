using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public bool goalConceded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            goalConceded = true;
        }
    }
}
