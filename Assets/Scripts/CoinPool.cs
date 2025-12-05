using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private float _coinCount;

    private Queue<Coin> _pool = new Queue<Coin>();

    private void OnEnable()
    {
        FillPool(_coinCount);
    }

    public bool TryGetCoin(out Coin coin)
    {
        coin = null;
        if (_pool.Count == 0)
        {
            return false;
        }

        coin = _pool.Dequeue();
        coin.gameObject.SetActive(true);

        return true;
    }

    public void ReturnCoinToPool(Coin unit)
    {
        unit.gameObject.SetActive(false);
        _pool.Enqueue(unit);
    }

    private void FillPool(float count)
    {
        for (int i = 0; i < count; i++)
        {
            Coin coin = Instantiate(_coinPrefab);
            coin.gameObject.SetActive(false);
            _pool.Enqueue(coin);
        }
    }
}