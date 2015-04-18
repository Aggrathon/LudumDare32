using UnityEngine;

public class FlightLook : MonoBehaviour {

    Transform target;
    Vector3 axel;

    public Vector3 offset = new Vector3(0, 1, -2);
    public float followDistance = 2f;
    public float followSpeed = 10f;

    void OnEnable()
    {
        findTarget();
        transform.rotation = target.rotation;
        axel = target.position + target.TransformDirection(offset);
        transform.position = axel + transform.forward * (-followDistance);
    }
	
	// Update is called once per frame
    void LateUpdate()
    {

        if (target == null)
            findTarget();
        if (target != null)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * followSpeed);
            Vector3 rotatedBit = transform.forward * (-followDistance);
            axel = Vector3.Slerp(axel, target.position + target.TransformDirection(offset), 1);//Time.deltaTime * followSpeed);
            transform.position = Vector3.Slerp(transform.position, axel + rotatedBit, 1);//Time.deltaTime * followSpeed);
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
