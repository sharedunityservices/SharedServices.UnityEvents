using System;
using SharedServices;
using SharedServices.V1;

namespace Services.UnityEvents
{
    public interface IUnityEventService : IService
    {
        event Action UpdateEvent;
        event Action FixedUpdateEvent;
        event Action LateUpdateEvent;
    }
}