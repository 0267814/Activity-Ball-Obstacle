using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.up; 
    [SerializeField] private float stepAngle = 0.01f;             

    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        transform.Rotate(rotationAxis * stepAngle, Space.Self);
    }
}