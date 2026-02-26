using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryCollectCoin(collision, out Coin coinToCollect))
        {
            coinToCollect.Collect();
        }
    }

    private bool TryCollectCoin(Collider2D collision, out Coin coinToCollect)
    {
        coinToCollect = null;

        if (collision.TryGetComponent(out Coin coin))
        {
            coinToCollect = coin;
            return true;
        }

        return false;
    }     
}
