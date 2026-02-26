using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    public bool HasTarget => Target != null;
    public ITargetable Target { get; private set; }
    public Transform TargetTransform { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Target != null)
        {
            return;
        }

        if (collision.TryGetComponent(out ITargetable target))
        {
            Target = target;
            TargetTransform = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ITargetable target) && target == Target)
        {
            Target = null;
            TargetTransform = null;
        }
    }
}
