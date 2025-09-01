using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EntityMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private KillZone _killZone;

    private void OnEnable()
    {
        _killZone.EnteredKillZone += Die;
    }

    private void Update()
    {
        SetPosition();
    }

    private void OnDisable()
    {
        _killZone.EnteredKillZone -= Die;
    }

    protected virtual void SetPosition()
    {
    }

    protected virtual void MoveToPosition(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void Die(EntityMovement entity)
    {
        Debug.Log("умерай");

        if(entity == this)
        {
            Destroy(this);
        }
    }
}
