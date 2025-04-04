using EventManagers;
using UnityEngine;

namespace Helmet
{
    public class HornsScript : MonoBehaviour
    {
        private static readonly int HornsUpTrigger = Animator.StringToHash("HornsUpTrigger");
        private static readonly int HornsDownTrigger = Animator.StringToHash("HornsDownTrigger");
        private static readonly int GoIdleTrigger = Animator.StringToHash("GoIdleTrigger");

        private Animator _animator;
        private bool _areHornsRaised;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
            if (_animator == null)
            {
                Debug.LogWarning("Animator component not found on the GameObject.");
            }
        }

        private void OnEnable()
        {
            CanvasEventManagerScript.EventButtonHornsClick += ToggleHorns;
        }

        private void OnDisable()
        {
            CanvasEventManagerScript.EventButtonHornsClick -= ToggleHorns;
        }

        public void ToggleHorns()
        {
            if (_animator == null) return;

            if (_areHornsRaised)
            {
                _animator.SetTrigger(HornsDownTrigger);
                PlayHornsSound();
                _areHornsRaised = false;
            }
            else
            {
                _animator.SetTrigger(HornsUpTrigger);
                PlayHornsSound();
                _areHornsRaised = true;
            }
        }

        private void PlayHornsSound()
        {
            if (_audioSource)
            {
                _audioSource.Play();
            }
        }

        public void GoToIdle()
        {
            if (_animator == null) return;
            _animator.SetTrigger(GoIdleTrigger);
        }
    }
}