using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public event Action<Coin> Died;

    public void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    public void Collect()
    {
        Died?.Invoke(this);
    }
}
