using System;
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
    }
}