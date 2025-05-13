using System.Collections.Generic;
using Script.GameScene.Exception;
using UnityEngine;

namespace Script.GameScene
{
    public class ObjectContainer : MonoBehaviour
    {
        public static ObjectContainer Instance { get; private set; }
        
        private Dictionary<string, ServedObject> objects = new Dictionary<string, ServedObject>();
        
        private void Awake()
        {
            Instance = this;
        }
        
        public void RegisterObject(ServedObject obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.id))
            {
                throw new System.ArgumentNullException(nameof(obj), "Object or ID cannot be null or empty.");
            }
            
            if (objects.ContainsKey(obj.id))
            {
                throw new DuplicatedException($"Object with ID {obj.id} already exists.");
            }
            
            objects[obj.id] = obj;
        }
        
        public ServedObject FindById(string id)
        {
            return objects.GetValueOrDefault(id, null);
        }
    }
}