using UnityEngine;

namespace Script.GameScene
{
    public class ServedObject : MonoBehaviour
    {
        public string id;

        public void UpdateObject(UpdatedObjectDto updatedObjectDto)
        {
            transform.position = new Vector3(
                updatedObjectDto.position.x, 
                updatedObjectDto.position.y, 
                0);
        }
    }
}