﻿using UnityEngine;
using System.Collections;

public class EMP : MonoBehaviour {

    public float shieldDamage = 100f;
    public bool dontDespawn = false;
    public GameObject blastPrefab;

    public void Blast()
    {
        if (blastPrefab != null)
        {
            SimplePool.Spawn(blastPrefab, transform.position, transform.rotation);
            SimplePool.Spawn(blastPrefab, transform.position, Quaternion.LookRotation(-transform.forward, transform.up));
        }
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
            SimplePool.Despawn(gameObject);
    }
}
