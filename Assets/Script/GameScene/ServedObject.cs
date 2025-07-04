using UnityEngine;

namespace Script.GameScene
{
    public class ServedObject : MonoBehaviour
    {
        public int id;
        private GameObject _effectInstance = null;
        private string master;
        
        public void SetMaster(string master)
        {
            this.master = master;
            if (master.Equals("RightPlayer"))
            {
                gameObject.transform.Rotate(0, 180, 0);
            }
        }

        public void UpdateObject(UpdatedObjectDto updatedObjectDto)
        {
            transform.position = new Vector3(
                updatedObjectDto.position.x, 
                updatedObjectDto.position.y, 
                0);
            if (updatedObjectDto.status.Equals("Destroyed"))
            {
                ObjectContainer.Instance.UnregisterObject(this);
                Destroy(gameObject);
            }
            else
            // TODO - Add Logic for Animation, State, Effect Atc
            SetEffect(updatedObjectDto.effect);
        }
        
        private void SetEffect(string effect)
        {
            if (effect.Equals("None"))
            {
                if (_effectInstance != null)
                {
                    Destroy(_effectInstance);
                    _effectInstance = null;
                }
                return;
            }
            
            GameObject effectPrefab = (GameObject) Resources.Load($"Prefabs/Effects/{effect}");
            if (effectPrefab == null)
            {
                Debug.LogWarning($"Effect prefab '{effect}' not found.");
                return;
            }
            if (_effectInstance != null)
            {
                Destroy(_effectInstance);
            }
            _effectInstance = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            _effectInstance.transform.SetParent(transform);
        }
    }
}