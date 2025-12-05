using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CoinPool))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Target _target;
    private CoinPool _pool;

    private void Awake()
    {
        _pool = GetComponent<CoinPool>();
    }

    public void TrySpawnCoin()
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