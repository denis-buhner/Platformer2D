using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField]private CoinPool _pool;

    public void SpawnCoin()
    {
        if(_pool.TryGetCoin(out Coin coin))
        {
            coin.Initialize(transform.position);
            coin.Died += DespawnCoin;
        }
    }

    private void DespawnCoin(Coin coin)
    {
        coin.Died -= DespawnCoin;

        _pool.ReturnCoinToPool(coin);
    }
}