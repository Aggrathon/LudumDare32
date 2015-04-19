using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StatusText : MonoBehaviour {

    Text text;

    int energy = 0;
    int hull = 0;

    ShipHealth health;
    Forcefield shields;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        foreach (ShipHealth sh in GameObject.FindObjectsOfType<ShipHealth>())
            if (!sh.Enemy)
                health = sh;
        shields = health.gameObject.GetComponentInChildren<Forcefield>();
	}

    void Update()
    {
        int newenergy = (int)(shields.getShieldEnergyPercent()*100);
        int newhull = (int)(health.getHealthPercent()*100);

        if (newenergy != energy || newhull != hull)
        {
            hull = newhull;
            energy = newenergy;
            text.text = "Battleship status\nShields: " + energy + "%\nHull: " + hull + "%";
        }
	}
}
