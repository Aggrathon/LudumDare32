using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlightController : MonoBehaviour {

    public float enginePower = 500f;
    public float engineReversePower = 300f;
    public float turnPower = 10f;
    public float mouseSensitivity = 10f;
    public float controllerSensitivity = 10f;
    public float maxCameraAngle = 45f;

    new private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        float roll = (Input.GetAxis("Mouse X") * mouseSensitivity +
            Input.GetAxis("Controller X")  * controllerSensitivity) * turnPower * Time.fixedDeltaTime;
        float pitch = (Input.GetAxis("Mouse Y") * mouseSensitivity +
            Input.GetAxis("Controller Y") * controllerSensitivity) * turnPower * Time.fixedDeltaTime;
        float yaw = Input.GetAxis("Horizontal") * turnPower * Time.fixedDeltaTime;
        float throttle = Input.GetAxis("Vertical");

        if (throttle > 0)
            rigidbody.AddForce(transform.forward * throttle * enginePower * Time.fixedDeltaTime, ForceMode.Acceleration);
        else
            rigidbody.AddForce(transform.forward * throttle * engineReversePower * Time.fixedDeltaTime, ForceMode.Acceleration);

        rigidbody.AddTorque(new Vector3(-roll, yaw, pitch), ForceMode.Acceleration);

        Vector3 rot = rigidbody.angularVelocity.normalized * Mathf.Min(rigidbody.angularVelocity.magnitude, maxCameraAngle);

        Camera.main.transform.rotation = transform.rotation * Quaternion.Euler(rot);

        //Debug.Log("roll: " + roll + " pitch: " + pitch + " yaw: " + yaw + " throttle: " + throttle);
    }



    public void OnCollisionEnter(Collision collision)
    {
        GameObject.FindObjectOfType<GamestateManager>().Die();
    }

    
}
