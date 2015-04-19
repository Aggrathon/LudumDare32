using UnityEngine;
using System.Collections;

public class ShipHealth : MonoBehaviour {

    [SerializeField]
    private float health = 100f;
    public bool enemy;

    public float Health { get { return health; } set { Damage(health - value); } }

    public void Damage(float amount)
    {
        health -= amount;
        if (health < 0)
        {
            if (enemy)
                GameObject.FindObjectOfType<GamestateManager>().Win();
            else
                GameObject.FindObjectOfType<GamestateManager>().Die();
        }

    }
}
