using System;
using SharedServices.V1;
using UnityEngine;

namespace SharedServices.UnityEvents.V1
{
    public interface IUnityEventSystemEventService : IService
    {
        event Action<GameObject> SelectionChangedEvent;
    }
}