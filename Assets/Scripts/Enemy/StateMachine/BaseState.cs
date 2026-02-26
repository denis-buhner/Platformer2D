using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    protected EnemyStateMachine StateMachine;
    protected EnemyComponents EnemyData;

    public virtual void Initialize(EnemyStateMachine stateMachine, EnemyComponents enemyData)
    {
        StateMachine = stateMachine;
        EnemyData = enemyData;
    }

    public virtual void Enter() { }
    public virtual void Tick() { }
    public virtual void Exit() { }
}
