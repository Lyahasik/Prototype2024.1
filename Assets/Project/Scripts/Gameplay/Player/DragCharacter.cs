using UnityEngine;
using UnityEngine.EventSystems;

using Prototype.Scripts.Gameplay.Player.Target;

namespace Prototype.Scripts.Gameplay.Player
{
    public class DragCharacter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private RunCharacter runCharacter;
        [SerializeField] private SettingTargetPoint settingTargetPoint;

        [Space]
        [SerializeField] private float sensitivity;

        public void OnPointerDown(PointerEventData eventData)
        {
            settingTargetPoint.SetStartPosition(transform.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            runCharacter.StartRun(settingTargetPoint.TargetPosition);
            settingTargetPoint.Hide();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector3 distance = eventData.position - eventData.pressPosition;
            (distance.y, distance.z) = (distance.z, distance.y);
            
            Vector3 targetPoint = transform.position + transform.TransformPoint(distance) * sensitivity;
            
            settingTargetPoint.SetTargetPosition(targetPoint);
        }
    }
}
