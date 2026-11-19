using UnityEngine;

[CreateAssetMenu(fileName = "TankData", menuName = "Scriptable Objects/TankData")]
public class TankData : ScriptableObject
{
    [Header("Tank Movement")] 
    public float moveSpeed = 20.0f;
    public float turnSpeed = 100.0f;
    public float smoothTime = 0.5f;
    public float maxDistance = 300.0f;
    
    [Header("Turret Stats")]
    public float turretRotateSpeed = 20.0f;
}
