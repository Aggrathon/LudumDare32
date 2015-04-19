using UnityEngine;
using System.Collections;

public class AutoCannon : MonoBehaviour {

    public GameObject round;
    public GameObject muzzleFlash;
    public Transform firePoint;
    public float fireRate = 0.5f;
    public float startDelay = 3f;
    public float muzzleVelocity = 100f;
    public float inaccuracy = 0.5f;

    float cooldown;

	// Use this for initialization
	void Start () {
        if (startDelay < 0)
            startDelay = Random.Range(0f, -startDelay);
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
        float angle = Random.Range(0f, 360f);
        float inacc = Random.Range(0f, inaccuracy);
        Vector3 dir = firePoint.eulerAngles + new Vector3(Mathf.Sin(angle) * inacc, Mathf.Cos(angle) * inacc, 0f);
        GameObject go = SimplePool.Spawn(round, firePoint.position, Quaternion.Euler(dir));
        SimplePool.Spawn(muzzleFlash, firePoint.position, firePoint.rotation);
        go.GetComponent<Rigidbody>().AddForce(go.transform.forward * muzzleVelocity, ForceMode.VelocityChange);
    }
}
