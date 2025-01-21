using EventManagers;
using UnityEngine;

public class HornsScript : MonoBehaviour
{
    private static readonly int HornsUpTrigger = Animator.StringToHash("HornsUpTrigger");
    private static readonly int HornsDownTrigger = Animator.StringToHash("HornsDownTrigger");
    private static readonly int GoIdleTrigger = Animator.StringToHash("GoIdleTrigger");

    private Animator _animator;
    private bool _areHornsRaised;

    private void Awake()
    {
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
            _areHornsRaised = false;
        }
        else
        {
            _animator.SetTrigger(HornsUpTrigger);
            _areHornsRaised = true;
        }
    }

    public void GoToIdle()
    {
        if (_animator == null) return;
        _animator.SetTrigger(GoIdleTrigger);
    }
}