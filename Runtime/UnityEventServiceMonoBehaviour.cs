using System;
using UnityEngine;

namespace Services.UnityEvents
{
    public class UnityEventServiceMonoBehaviour : MonoBehaviour
    {
        public event Action UpdateEvent;
        public event Action FixedUpdateEvent;
        public event Action LateUpdateEvent;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        private void Update() => UpdateEvent?.Invoke();
        private void FixedUpdate() => FixedUpdateEvent?.Invoke();
        private void LateUpdate() => LateUpdateEvent?.Invoke();
    }
}