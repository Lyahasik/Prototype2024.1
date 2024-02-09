using UnityEngine;

namespace Prototype.Scripts.Gameplay.Player.Target
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(MeshRenderer))]
    public class ColorSwitcher : MonoBehaviour
    {
        private Material _targetMaterial;

        private void Awake() => 
            _targetMaterial = GetComponent<MeshRenderer>().material;

        private void OnTriggerEnter(Collider other) => 
            _targetMaterial.color = Color.red;

        private void OnTriggerExit(Collider other) => 
            _targetMaterial.color = Color.white;
    }
}