using System;
using SharedServices;
using SharedServices.V1;
using UnityEngine;

namespace Services.UnityEvents
{
    public interface IUnityEventSystemEventService : IService
    {
        event Action<GameObject> SelectionChangedEvent;
    }
}