using UnityEngine;

public class EnemyComponents : MonoBehaviour
{
    [field: SerializeField] public TargetFinder TargetFinder {  get; private set; }
    [field: SerializeField] public EnemyChasing EnemyChasing { get; private set; }
    [field: SerializeField] public EnemyAttack EnemyAttack { get; private set; }
    [field: SerializeField] public EnemyPatrol EnemyPatrol { get; private set; }
    [field: SerializeField] public EnemyIdle EnemyIdle { get; private set; }
}
