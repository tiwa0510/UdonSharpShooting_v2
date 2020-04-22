using UdonSharp;
using UnityEngine;

public class ResetTransform : UdonSharpBehaviour
{
    Vector3 startPosition;
    Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void Execute()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }
}
