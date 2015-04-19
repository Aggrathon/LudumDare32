using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FlightController : MonoBehaviour {

    public float enginePower = 600f;
    public float engineReversePower = 400f;
    public float engineBoostMultiplier = 2.5f;
    public float turnPower = 10f;

    public float destroySpeed = 20f;

    [Header("Input")]
    public float mouseSensitivity = 5f;
    public float controllerSensitivity = 5f;

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
        {
            if (Input.GetButton("Boost"))
                throttle *= engineBoostMultiplier; 
            rigidbody.AddForce(transform.forward * throttle * enginePower * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        else
            rigidbody.AddForce(transform.forward * throttle * engineReversePower * Time.fixedDeltaTime, ForceMode.Acceleration);

        Vector3 torque =
            -transform.forward * roll +
            transform.up * yaw +
            transform.right * pitch;

        rigidbody.AddTorque(torque, ForceMode.Acceleration);
        //Debug.Log("roll: " + roll + " pitch: " + pitch + " yaw: " + yaw + " throttle: " + throttle);
    }



    public void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > destroySpeed)
            GameObject.FindObjectOfType<GamestateManager>().Die();
    }

    
}
