using System.Collections;
using UnityEngine;

public class IdleState : BaseState
{
    public override void Enter()
    {
        EnemyData.EnemyIdle.StartIdle();
    }

    public override void Tick()
    {
        if (EnemyData.TargetFinder.HasTarget)
        {
            StateMachine.ChangeState<ChaseState>();
            return;
        }

        if(EnemyData.EnemyIdle.IsIdle == false)
        {
            StateMachine.ChangeState<PatrolState>();
            return;
        }
    }

    public override void Exit()
    {
        EnemyData.EnemyIdle.StopIdle();
    }
}
