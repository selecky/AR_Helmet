using UnityEngine;

public class HornsToggler : MonoBehaviour
{
    private static readonly int HornsUpTrigger = Animator.StringToHash("HornsUpTrigger");
    private static readonly int HornsDownTrigger = Animator.StringToHash("HornsDownTrigger");
    private static readonly int GoIdleTrigger = Animator.StringToHash("GoIdleTrigger");
    private bool _areHornsUp;


    public void ToggleHorns()
    {
        var horns = FindAnyObjectByType<TagHorns>()?.gameObject;
        var animator = horns?.GetComponent<Animator>();


        // horns up
        if (!_areHornsUp)
        {
            animator?.SetTrigger(HornsUpTrigger);
            _areHornsUp = true;
        }


        // horns down
        else 
        {
            animator?.SetTrigger(HornsDownTrigger);
            _areHornsUp = false;
        }
       
    }


    public void GoToIdle()
    {
        var horns = FindAnyObjectByType<TagHorns>()?.gameObject;
        var animator = horns?.GetComponent<Animator>();
        animator?.SetTrigger(GoIdleTrigger);
    }
}