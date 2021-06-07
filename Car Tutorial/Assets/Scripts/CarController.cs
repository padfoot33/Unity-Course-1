using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
	public WheelCollider frontRightWC, frontLeftWC, rearRightWC, rearLeftWC;
	public Transform frontRightT, frontLeftT, rearRightT, rearLeftT;
	public float maxSteerAngle = 30f;
	public float motorForce = 50f;

	private float horizontalInput;
	private float verticalInput;
	private float currentSteeringAngle;

    private void FixedUpdate()
    {
		GetInput();
		SteerWheel();
		Accelerate();
		UpdatePoses();
	}

	private void GetInput()
    {
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
    }
	private void SteerWheel()
	{
		currentSteeringAngle = maxSteerAngle * horizontalInput;
		frontRightWC.steerAngle = currentSteeringAngle;
		frontLeftWC.steerAngle = currentSteeringAngle;
	}

	private void Accelerate()
    {
		frontRightWC.motorTorque = motorForce * verticalInput;
		frontLeftWC.motorTorque = motorForce * verticalInput;
	}

	private void UpdatePoses()
    {
		UpdatePose(frontLeftWC, frontLeftT);
		UpdatePose(frontRightWC, frontRightT);
		UpdatePose(rearLeftWC, rearLeftT);
		UpdatePose(rearRightWC, rearRightT);
	}

	private void UpdatePose(WheelCollider wheelCollider, Transform wheelTransform)
    {
		Vector3 wheelPos = wheelTransform.position;
		Quaternion wheelRotation = wheelTransform.rotation;

		wheelCollider.GetWorldPose(out wheelPos, out wheelRotation);

		wheelTransform.position = wheelPos;
		wheelTransform.rotation = wheelRotation;
	}
	
}