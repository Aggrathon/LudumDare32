using UnityEngine;
using System.Collections;

public class Forcefield : MonoBehaviour {

    public GameObject impact;

    public float maxEnergy = 1000f;
    public float energyRegeneration = 40f;
    public float energyDrain = 10f;

    [Header("Only for debug")]
    public float energy;

    void Start()
    {
        energy = maxEnergy;
    }

    void Update()
    {
        if (energy < maxEnergy)
            energy += energyRegeneration * Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || energy < energyDrain)
            return;

        energy -= energyDrain;
        SimplePool.Spawn(impact, other.transform.position, Quaternion.Euler(-other.transform.forward));
        SimplePool.Despawn(other.gameObject);
    }

    public float getShieldEnergyPercent()
    {
        return energy / maxEnergy;
    }

	
}
