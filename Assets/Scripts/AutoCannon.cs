using UnityEngine;
using System.Collections;

public class AutoCannon : MonoBehaviour {

    public GameObject round;
    public GameObject muzzleFlash;
    public Transform firePoint;
    public float fireRate;
    public float startDelay;
    public float muzzleVelocity;

    float cooldown;

	// Use this for initialization
	void Start () {
        cooldown = startDelay;
	}
	
	void FixedUpdate () {
        cooldown -= Time.fixedDeltaTime;
        if (cooldown < 0)
        {
            Fire();
            cooldown += fireRate;
        }
	}

    void Fire()
    {
        GameObject go = SimplePool.Spawn(round, firePoint.position, firePoint.rotation);
        SimplePool.Spawn(muzzleFlash, firePoint.position, firePoint.rotation);
        go.GetComponent<Rigidbody>().AddForce(firePoint.forward * muzzleVelocity, ForceMode.VelocityChange);
    }
}
