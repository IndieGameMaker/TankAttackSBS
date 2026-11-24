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
    public float recenterDelayTime = 2.0f;
    
    [Header("Cannon Stats")]
    public float cannonRotateSpeed = 10.0f;
    public float upwardsLimitAngle = -20.0f;
    public float downwardsLimitAngle = 10.0f;

    [Header("Projectile Stats")] 
    public float cannonForce = 1000.0f;
    public float cannonDamage = 20.0f;
    public float reloadTime = 1.0f;
    public GameObject explosionPrefab;

}
