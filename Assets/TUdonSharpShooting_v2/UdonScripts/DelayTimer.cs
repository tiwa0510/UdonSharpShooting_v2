
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DelayTimer : UdonSharpBehaviour
{
    [SerializeField] UdonSharpBehaviour[] targetUdons;
    [SerializeField] string[] eventNames;

    int capacity;
    float[] delayTimes;
    float[] startTimes;

    private void Start()
    {
        capacity  = targetUdons.Length;
        delayTimes = new float[capacity];
        startTimes = new float[capacity];
        for(int i = 0; i < capacity; i++)
        {
            startTimes[i] = -1;
        }
    }

    public void StartTimer(string eventName, float delay)
    {
        int index = -1;
        for(int i = 0; i < capacity; i++)
        {
            if(eventNames[i] == eventName)
            {
                index = i;
                break;
            }
        }
        if (index == -1) return;
        startTimes[index] = Time.time;
        delayTimes[index] = delay;
    }

    public void StopTimer(int index)
    {
        startTimes[index] = -1;
    }

    private void Update()
    {
        for (int i = 0; i < capacity; i++)
        {
            if (startTimes[i] < 0) continue;

            if (delayTimes[i] <= Time.time - startTimes[i])
            {
                targetUdons[i].SendCustomEvent(eventNames[i]);
                startTimes[i] = -1;
            }
        }
    }
}
