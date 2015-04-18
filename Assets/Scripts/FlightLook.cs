using UnityEngine;

public class FlightLook : MonoBehaviour {

    Vector3 rotation;
    Transform target;

    public float sensitivity = 6f;
    public float maxAngle = 90f;

    public float followDistance = 4f;
    public float followSpeed = 1f;

	// Use this for initialization
	void Start () {
        rotation = transform.rotation.eulerAngles;
	}
    void OnEnable()
    {
        findTarget();
        transform.position = getTargetPos();
    }
	
	// Update is called once per frame
	void Update () {
        rotation.x = transform.localEulerAngles.x + Input.GetAxis("Mouse Y") * sensitivity;
        rotation.z = transform.localEulerAngles.z - Mathf.Clamp(Input.GetAxis("Mouse X") * sensitivity, -maxAngle, maxAngle);


        transform.localEulerAngles = rotation;
        transform.position = Vector3.Lerp(transform.position, getTargetPos(), Time.deltaTime*followSpeed);
	}

    Vector3 getTargetPos()
    {
        if (target == null)
        {
            
            Vector3 offset = (target.forward - transform.forward).normalized * (-followDistance);
            return target.position + offset;
        }
        else
            return Vector3.zero;
    }

    void findTarget()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if(go != null)
            target = go.transform;
    }

    public float getAngleX()
    {
        return 0f;
    }
    public float getAngleZ()
    {
        return 0f;
    }
}
