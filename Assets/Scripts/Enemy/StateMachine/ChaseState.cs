using UnityEngine;

public class ChaseState : BaseState
{
    public override void Enter()
    {
        EnemyData.EnemyChasing.StartChasing(EnemyData.TargetFinder.TargetTransform);
    }

    public override void Tick()
    {
        if (EnemyData.TargetFinder.Target == null)
        {
            StateMachine.ChangeState<PatrolState>();
            return;
        }

        if(EnemyData.EnemyChasing.IsArrived)
        {
            StateMachine.ChangeState<AttackState>();
        }
    }

    public override void Exit()
    {
        EnemyData.EnemyChasing.StopChasing();
    }
}
