using UnityEngine;

public class RocketArmShadow : MonoBehaviour
{
    public static Transform AttackPoint { get; set; }

    public bool Trace { get; private set; }
    public bool Punch { get; private set; }


    private void Awake()
    {
        AttackPoint = GetComponent<Transform>();
    }

    private void TracePlayer()
    {
        Trace = true;
    }

    private void StopTracePlayer()
    {
        Trace = false;
    }


    private void PunchDownTrigger()
    {
        Punch = true;
    }

    private void PunchUpTrigger()
    {
        Punch = false;
    }
}
