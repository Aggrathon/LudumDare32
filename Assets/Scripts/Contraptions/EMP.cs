using UnityEngine;
using System.Collections;

public class EMP : MonoBehaviour {

    public float shieldDamage = 100f;
    public bool dontDespawn = false;

    public void Blast()
    {
        foreach (Collider col in Physics.OverlapSphere(transform.position, 1f))
        {
            Forcefield ff = col.transform.GetComponent<Forcefield>();
            if (ff != null)
            {
                ff.energy -= shieldDamage;
                break;
            }
        }
        if(!dontDespawn)
            SimplePool.Despawn(transform.parent.gameObject);
    }
}
