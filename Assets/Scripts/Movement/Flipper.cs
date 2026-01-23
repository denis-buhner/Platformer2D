using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float _rotationAngle = 180;

    private Transform _transform;

    public void Initialize(Transform transform)
    {
        _transform = transform;
    }

    public void Flip()
    {
        _transform.Rotate(0, _rotationAngle, 0);
    }
}
