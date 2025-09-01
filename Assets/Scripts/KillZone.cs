using System;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public event Action<EntityMovement> EnteredKillZone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�����");

        if (collision.TryGetComponent<EntityMovement>(out var entity))
        {
            Debug.Log("�����2");
            EnteredKillZone?.Invoke(entity);
        }
    }
}
