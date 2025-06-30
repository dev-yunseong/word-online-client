using UnityEngine;

namespace Script.GameScene
{
    public class ObjectUpdater : MonoBehaviour
    {
        public static ObjectUpdater Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
        
        public void UpdateObject(UpdatedObjectDto updatedObjectDto)
        {
            ServedObject servedObject = ObjectContainer.Instance.FindById(updatedObjectDto.id);
            if (servedObject != null)
            {
                servedObject.UpdateObject(updatedObjectDto);
            }
            // TODO - Add Logic for Animation, State, Effect Atc
        }
    }
}