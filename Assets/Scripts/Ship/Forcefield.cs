using UnityEngine;
using System.Collections;

public class Forcefield : MonoBehaviour {

    public GameObject impact;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            return;


        if (Quaternion.Angle(other.transform.rotation, Quaternion.Euler(transform.position - other.transform.position)) < 180)
        {
            SimplePool.Despawn(other.gameObject);
            SimplePool.Spawn(impact, other.transform.position, Quaternion.Euler(-other.transform.forward));
        }
    }

	
}
