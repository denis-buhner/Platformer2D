using UnityEngine;

public class AttackState : BaseState
{
    private Transform _target;
    public override void Enter()
    {
        _target = EnemyData.TargetFinder.TargetTransform;
    }

    public override void Tick()
    {
        if (_target == null)
        {
            StateMachine.ChangeState<PatrolState>();
            return;
        }

        if (!EnemyData.EnemyAttack.CanAttack(_target))
        {
            StateMachine.ChangeState<ChaseState>();
            return;
        }

        EnemyData.EnemyAttack.Attack(EnemyData.TargetFinder.Target);
    }

    public override void Exit()
    {
        _target = null;
    }
}
