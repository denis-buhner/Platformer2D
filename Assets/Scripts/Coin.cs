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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            Died?.Invoke(this);
        }
    }
}
