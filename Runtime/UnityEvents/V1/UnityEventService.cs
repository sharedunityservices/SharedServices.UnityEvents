using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SharedServices.UnityEvents.V1
{
    [UnityEngine.Scripting.Preserve]
    public class UnityEventService : IUnityEventService, IDisposable
    {
        private static UnityEventServiceMonoBehaviour _unityEventService;
        public event Action UpdateEvent = delegate { };
        public event Action FixedUpdateEvent = delegate { };
        public event Action LateUpdateEvent = delegate { };

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            _unityEventService = GameObjectUtil.CreateDDOLWith<UnityEventServiceMonoBehaviour>("UnityEventService");
        }

        public UnityEventService()
        {
            GameObjectUtil.WaitUntil(() => _unityEventService, () =>
            {
                _unityEventService.UpdateEvent += InvokeUpdateEvent;
                _unityEventService.FixedUpdateEvent += InvokeFixedUpdateEvent;
                _unityEventService.LateUpdateEvent += InvokeLateUpdateEvent;
            });
        }

        public void Dispose()
        {
            _unityEventService.UpdateEvent -= InvokeUpdateEvent;
            _unityEventService.FixedUpdateEvent -= InvokeFixedUpdateEvent;
            _unityEventService.LateUpdateEvent -= InvokeLateUpdateEvent;
            if (_unityEventService)
                Object.Destroy(_unityEventService.gameObject);
        }

        private void InvokeUpdateEvent() => UpdateEvent.Invoke();
        private void InvokeFixedUpdateEvent() => FixedUpdateEvent.Invoke();
        private void InvokeLateUpdateEvent() => LateUpdateEvent.Invoke();
    }
}