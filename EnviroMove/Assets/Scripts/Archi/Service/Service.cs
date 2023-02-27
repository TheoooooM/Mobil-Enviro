﻿using System.Collections.Generic;
using Archi.Service.Interface;
using Attributes;
using UnityEngine;

namespace Archi.Service
{
    public abstract class Service : IService
    {
        protected bool currentServiceState = true;
        protected List<GameObject> gameObjectDependency;

        [InitializedOnCompose]
        protected abstract void Initialize();

        public virtual void SetServiceState(bool state)
        {
            currentServiceState = state;
            for (int i = 0; i < gameObjectDependency.Count; i++)
            {
                gameObjectDependency[i].SetActive(state);
            }
        }

        public virtual bool SwitchServiceState()
        {
            SetServiceState(!currentServiceState);
            return currentServiceState;
        }
    }
}