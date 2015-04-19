using UnityEngine;
using System.Collections;

public class HangarLauncher : MonoBehaviour {

    public GameObject fighter;
    public GameObject launchPoint;
    public float launchSpeed = 30f;

    void OnEnable()
    {
        fighter.transform.position = launchPoint.transform.position;
        fighter.transform.rotation = launchPoint.transform.rotation;
        Rigidbody rig = fighter.GetComponent<Rigidbody>();
        rig.AddForce(fighter.transform.forward*launchSpeed, ForceMode.VelocityChange);
        rig.AddTorque(Vector3.zero, ForceMode.VelocityChange);

        foreach (TrailRenderer tr in fighter.GetComponentsInChildren<TrailRenderer>())
        {
            StartCoroutine(ResetTrail(tr));   
        }
    }
 
     /// <summary>
     /// Coroutine to reset a trail renderer trail
     /// </summary>
     /// <param name="trail"></param>
     /// <returns></returns>
     static IEnumerator ResetTrail(TrailRenderer trail)
     {
         var trailTime = trail.time;
         trail.time = 0;
         yield return 0;
         trail.time = trailTime;
     }  
}
