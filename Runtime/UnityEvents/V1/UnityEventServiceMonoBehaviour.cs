using System;
using UnityEngine;

namespace SharedServices.UnityEvents.V1
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