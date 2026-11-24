using UnityEngine;

public class Cannon : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1500.0f);
    }
}
