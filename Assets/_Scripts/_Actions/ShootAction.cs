using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts._Actions;
using Cinemachine;
using UnityEngine;

public class ShootAction : BaseAction
{
    private enum State
    {
        Aiming,
        Shooting,
        Cooloff,
    }

    private State _state;
    private int _maxShootDistance = 7;
    private float _stateTimer;
    private Unit _targetUnit;
    private bool _canShootBullet;

    private void Update()
    {
        if (!IsActive)
        {
            return;
        }

        _stateTimer -= Time.deltaTime;

        switch (_state)
        {
            case State.Aiming:
                Vector3 aimDirection = (_targetUnit.GetWorldPosition() - Unit.GetWorldPosition()).normalized;
                float rotateSpeed = 10f;
                transform.forward = Vector3.Slerp(transform.forward, aimDirection, Time.deltaTime * rotateSpeed);
                break;
            case State.Shooting:
                if (_canShootBullet)
                {
                    Shoot();
                    _canShootBullet = false;
                }
                break;
            case State.Cooloff:
                break;
        }

        if (_stateTimer <= 0f)
        {
            NextState();
        }
    }

    private void Shoot()
    {
        _targetUnit.Damage();
    }
    
    private void NextState()
    {
        switch (_state)
        {
            case State.Aiming:
                _state = State.Shooting;
                float shootingStateTime = .1f;
                _stateTimer = shootingStateTime;
                break;
            case State.Shooting:
                _state = State.Cooloff;
                float coolOffStateTime = .5f;
                _stateTimer = coolOffStateTime;
                break;
            case State.Cooloff:
                ActionComplete();
                break;
        }
    }

    public override string GetActionName()
    {
        return "Shoot";
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        ActionStart(onActionComplete);

        _targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(gridPosition);
        
        _state = State.Aiming;
        float aimingStateTime = 1f;
        _stateTimer = aimingStateTime;

        _canShootBullet = true;
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = Unit.GetGridPosition();
        for (int i = -_maxShootDistance; i <= _maxShootDistance; i++) // X AXIS!!!
        {
            for (int j = -_maxShootDistance; j <= _maxShootDistance; j++) // Z AXIS!!!
            {
                GridPosition offsetGridPosition = new GridPosition(i, j);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                int testDistance = Mathf.Abs(i) + Mathf.Abs(j);
                if (testDistance > _maxShootDistance)
                {
                    continue;
                }


                if (!LevelGrid.Instance.HasAnyUnitOnThisGridPosition(testGridPosition))
                {
                    // Grid position is empty, no unit!
                    continue;
                }

                Unit targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(testGridPosition);

                if (targetUnit.IsEnemy() == Unit.IsEnemy())
                {
                    // Both Units on the same "Team".
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }
}