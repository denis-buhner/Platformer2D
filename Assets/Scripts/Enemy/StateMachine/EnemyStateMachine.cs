using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent (typeof(IdleState), typeof(ChaseState), typeof(AttackState))]
[RequireComponent(typeof(PatrolState), typeof(DeathState))]

public class EnemyStateMachine : MonoBehaviour
{
    [Header("States")]
    [SerializeField] private IdleState _idleState;
    [SerializeField] private ChaseState _chaseState;
    [SerializeField] private AttackState _attackState;
    [SerializeField] private PatrolState _patrolState;
    [SerializeField] private DeathState _deathState;

    [Header("Components")]
    [SerializeField] private EnemyComponents _enemyData;
    [SerializeField] private float _timeBetweenChecks;
    [SerializeField] private Health _health;

    private Dictionary<Type, BaseState> _states;
    private Coroutine _stateUpdateCoroutine;
    private BaseState _currentState;

    public void StartStateMachine()
    {
        _states = GetComponents<BaseState>().ToDictionary(state => state.GetType());

        foreach(var state in _states.Values)
        {
            state.Initialize(this, _enemyData);
        }

        if (_stateUpdateCoroutine != null)
            StopCoroutine(_stateUpdateCoroutine);
        _stateUpdateCoroutine = StartCoroutine(StateUpdateTick());

        ChangeState<IdleState>();
        _health.IsDead += ChangeState<DeathState>;
    }

    public void StopStateMachine()
    {
        _health.IsDead -= ChangeState<DeathState>;

        if (_stateUpdateCoroutine == null)
            return;

        StopCoroutine(_stateUpdateCoroutine);
        _stateUpdateCoroutine = null;
    }

    public void ChangeState<TState>() where TState : BaseState
    {
        if (_states.TryGetValue(typeof(TState), out var newState))
        {
            if (_currentState == newState)
                return;

            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }
    }

    private IEnumerator StateUpdateTick()
    {
        yield return new WaitForEndOfFrame();

        while (isActiveAndEnabled)
        {
            _currentState?.Tick();

            yield return new WaitForSeconds(_timeBetweenChecks);
        }
    }
}
