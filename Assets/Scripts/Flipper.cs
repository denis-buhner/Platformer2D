using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float rotationAngle = 180;

    private Transform _transform;

    public void Initialize(Transform transform)
    {
        _transform = transform;
    }

    public void Flip()
    {
        _transform.Rotate(0, rotationAngle, 0);
    }
}
