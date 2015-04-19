using UnityEngine;

public class FlightLook : MonoBehaviour {

    Transform target;

    public Vector3 offset = new Vector3(0, 1, -2);
    public float followDistance = 2f;
    public float followSpeed = 10f;

    void OnEnable()
    {
        findTarget();
        transform.rotation = target.rotation;
        transform.position = target.position + target.TransformDirection(offset) + transform.forward * (-followDistance);
    }
	
	// Update is called once per frame
    void FixedUpdate()
    {

        if (target == null)
            findTarget();
        if (target != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * followSpeed);
            Vector3 rotatedBit = transform.forward * (-followDistance);
            Vector3 axel = target.position + target.TransformDirection(offset);
            transform.position = Vector3.Slerp(transform.position, axel + rotatedBit, Time.deltaTime * followSpeed);
        }
    }

    void findTarget()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go != null)
            target = go.transform;
        else
            Debug.Log("Camera couldn't Find Player");
    }
}
