using System;
using SharedServices.Locator;
using SharedServices.Locator.V1;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.UnityEvents
{
    public class UnityEventSystemEventService : IUnityEventSystemEventService
    {
        public event Action<GameObject> SelectionChangedEvent = delegate { };
        private IUnityEventService _unityEventService;
        private GameObject _selectedGameObject;
        
        public void Initialize()
        {
            _unityEventService = Service.Get<IUnityEventService>();
            _unityEventService.UpdateEvent += OnUpdate;
        }

        private void OnUpdate()
        {
            if (!EventSystem.current)
            {
                if (_selectedGameObject == null) return;
                _selectedGameObject = null;
                SelectionChangedEvent.Invoke(null);
            }
            else
            {
                var selectedGameObject = EventSystem.current.currentSelectedGameObject;
                if (selectedGameObject == _selectedGameObject) return;
                _selectedGameObject = selectedGameObject;
                SelectionChangedEvent.Invoke(selectedGameObject);
            }
        }
    }
}