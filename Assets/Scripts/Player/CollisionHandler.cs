using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Coin>() != null)
        {
            collision.GetComponent<Coin>().Collect();
        }
    }
}
