using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float _rotationAngle = 180;

    public void Flip()
    {
        transform.Rotate(0, _rotationAngle, 0);
    }
}
