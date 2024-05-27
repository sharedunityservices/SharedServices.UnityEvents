using System;
using SharedServices.V1;

namespace SharedServices.UnityEvents.V1
{
    public interface IUnityEventService : IService
    {
        event Action UpdateEvent;
        event Action FixedUpdateEvent;
        event Action LateUpdateEvent;
    }
}