using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts._Actions
{
    public abstract class BaseAction : MonoBehaviour
    {
        protected Unit Unit;
        protected bool IsActive;
        protected Action onActionComplete;

        protected virtual void Awake()
        {
            Unit = GetComponent<Unit>();
        }

        public abstract string GetActionName();

        public abstract void TakeAction(GridPosition gridPosition, Action onActionComplete);

        public virtual bool IsValidActionGridPosition(GridPosition gridPosition)
        {
            List<GridPosition> validGridPositionList = GetValidActionGridPositionList();
            return validGridPositionList.Contains(gridPosition);
        }

        public abstract List<GridPosition> GetValidActionGridPositionList();

        public virtual int GetActionPointsCost()
        {
            return 1;
        }

        protected void ActionStart(Action onActionComplete)
        {
            IsActive = true;
            this.onActionComplete = onActionComplete;
        }

        protected void ActionComplete()
        {
            IsActive = false;
            onActionComplete();
        }
    }
}