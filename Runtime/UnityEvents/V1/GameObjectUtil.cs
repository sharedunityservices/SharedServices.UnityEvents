using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace SharedServices.UnityEvents.V1
{
    public static class GameObjectUtil
    {
        public static T CreateWith<T>(string name = null) where T : Component
        {
            name ??= typeof(T).Name;
            var gameObject = new UnityEngine.GameObject(name);
            return gameObject.AddComponent<T>();
        }

        public static T CreateDDOLWith<T>(string name = null) where T : Component
        {
            name ??= typeof(T).Name;
            var gameObject = new UnityEngine.GameObject(name);
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            return gameObject.AddComponent<T>();
        }

        public static void WaitUntil(Func<bool> waitUntil, Action action)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(5000);
            try
            {
                Task.Run(async () =>
                {
                    while (!waitUntil.Invoke())
                    {
                        await Task.Yield();
                    }
                    action.Invoke();
                }, cts.Token);
            }
            catch (OperationCanceledException)
            {
                if (Application.isPlaying)
                    Debug.LogError("Initialization timed out");
            }
        }
    }
}