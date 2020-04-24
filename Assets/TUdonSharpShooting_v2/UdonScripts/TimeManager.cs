
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TimeManager : UdonSharpBehaviour
{
    [SerializeField] float timeMax;
    [UdonSynced(UdonSyncMode.None)]
    float time;
    [UdonSynced(UdonSyncMode.None)]
    bool isStart;

    void Start()
    {
        time = timeMax;
    }

    private void Update()
    {
        if (!isStart) return;
        time -= Time.deltaTime;
        isStart = true;

        if(time < 0)
        {
            time = 0;
            isStart = false;
        }
    }

    public void StartTimeCount()
    {
        time = timeMax;
        isStart = true;
    }

    public void StopTimeCount()
    {
        isStart = false;
    }

    public void ResumeTimeCount()
    {
        isStart = true;
    }

    public float GetTime()
    {
        return time;
    }

    public int GetTimeInt()
    {
        return Mathf.FloorToInt(time);
    }

    public float GetTimeFloor(int n)
    {
        return Mathf.Floor(time * Mathf.Pow(10, n)) / Mathf.Pow(10, n);
    }

    public bool IsStart()
    {
        return isStart;
    }
}