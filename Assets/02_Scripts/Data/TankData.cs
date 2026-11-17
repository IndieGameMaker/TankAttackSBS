using UnityEngine;

[CreateAssetMenu(fileName = "TankData", menuName = "Scriptable Objects/TankData")]
public class TankData : ScriptableObject
{
    [Header("Tank Movement")] 
    public float moveSpeed = 20.0f;
    public float turnSpeed = 100.0f;
}
