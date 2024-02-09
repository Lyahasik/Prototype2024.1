using UnityEngine;

namespace Prototype.Scripts.Gameplay.Player
{
    public class RunCharacter : MonoBehaviour
    {
        [SerializeField] private Animator characterAnimator;
        [SerializeField] private Transform transformMesh;

        [Space]
        [SerializeField] private float timeRun;
        [SerializeField] private AnimationCurve curveSpeed;
        
        private const string RunningKeyAnimator = "IsRunning";
        private int _runningIdAnimator;

        private Vector3 _targetPosition;
        private Vector3 _startPosition;
        private float _timePassed;
        private bool _isRunning;

        private void Awake() => 
            _runningIdAnimator = Animator.StringToHash(RunningKeyAnimator);

        private void Update() => 
            MakeStep();

        private void MakeStep()
        {
            if (_isRunning == false)
                return;

            _timePassed += Time.deltaTime;
            float progressRun = Mathf.Clamp(_timePassed / timeRun, 0f, 1f);

            transform.position = Vector3.Lerp(_startPosition, _targetPosition, curveSpeed.Evaluate(progressRun));

            if (progressRun >= 1f)
            {
                _isRunning = false;
                _timePassed = 0f;
                SetActiveRun(_isRunning);
            }
        }

        public void StartRun(in Vector3 targetPosition)
        {
            _isRunning = true;
            _startPosition = transform.position;
            _targetPosition = targetPosition;
            
            transformMesh.LookAt(_targetPosition);
                
            SetActiveRun(_isRunning);
        }

        private void SetActiveRun(in bool value) => 
            characterAnimator.SetBool(_runningIdAnimator, value);
    }
}