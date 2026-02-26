using UnityEngine;

public class PatrolState : BaseState
{
    public override void Enter()
    {
        EnemyData.EnemyPatrol.StartPatrolling();
    }

    public override void Tick()
    {
        if(EnemyData.TargetFinder.HasTarget)
        {
            StateMachine.ChangeState<ChaseState>();
            return;
        }

        if (EnemyData.EnemyPatrol.IsArrived)
        {
            StateMachine.ChangeState<IdleState>();
            return;
        }
    }

    public override void Exit()
    {
        EnemyData.EnemyPatrol.StopPatrolling();
    }
}
