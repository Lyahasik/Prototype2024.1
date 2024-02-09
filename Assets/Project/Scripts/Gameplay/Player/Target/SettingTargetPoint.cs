using UnityEngine;

namespace Prototype.Scripts.Gameplay.Player.Target
{
    public class SettingTargetPoint : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private LineRenderer lineRenderer;
        
        private Vector3 _startPosition;

        public Vector3 TargetPosition => target.transform.position;

        public void Hide()
        {
            target.SetActive(false);
            lineRenderer.gameObject.SetActive(false);
        }

        public void SetStartPosition(Vector3 transformPosition)
        {
            _startPosition = transformPosition;
        }

        public void SetTargetPosition(in Vector3 newPosition)
        {
            target.transform.position = newPosition;
            Show();

            UpdateLineRenderer();
        }

        private void Show()
        {
            target.SetActive(true);
            lineRenderer.gameObject.SetActive(true);
        }

        private void UpdateLineRenderer()
        {
            lineRenderer.SetPosition(0, _startPosition);
            lineRenderer.SetPosition(1, target.transform.position);
        }
    }
}
