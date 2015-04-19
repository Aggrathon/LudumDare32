using UnityEngine;
using System.Collections;

public class Explosive : MonoBehaviour {

    public bool explodeOnCollision = true;
    public float explosionRange = 20f;
    public float explosionDamage = 10f;
    public GameObject explosionPrefab;

    public void Explode()
    {
        SimplePool.Spawn(explosionPrefab, transform.position, transform.rotation);
        foreach (Collider c in Physics.OverlapSphere(transform.position, explosionRange))
        {
            ShipHealth sh = c.transform.GetComponent<ShipHealth>();
            if (sh != null)
                sh.Damage(explosionDamage);
        }
        SimplePool.Despawn(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (explodeOnCollision)
            Explode();
    }

}
