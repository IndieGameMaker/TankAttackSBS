using UnityEngine;

public class Cannon : MonoBehaviour
{
    private TankData _tankData;
    private int _actorNumber;

    public void Init(TankData tankData, int actorNumber)
    {
        _tankData = tankData;
        _actorNumber = actorNumber;
    }
    
    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _tankData.cannonForce);
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        coll.gameObject.GetComponent<IDamageable>()?.TakeDamage(_tankData.cannonDamage, _actorNumber);

        // if (coll.gameObject.TryGetComponent<IDamageable>(out var damageable))
        // {
        //     damageable.TakeDamage(_tankData.cannonDamage);
        // }
        
        
        var effect = Instantiate(_tankData.explosionPrefab, coll.contacts[0].point, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
