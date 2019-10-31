using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontRight, frontLeft, backRight, backLeft;
    private float driveVertical, steer;
    public float driveForce, steerAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0.5)
        {
            driveVertical = driveForce;
        }
        else if (Input.GetAxis("Vertical") < -0.5)
        {
            driveVertical = driveForce * -1;
        }
        else
        {
            driveVertical = 0;
        }

        if (Input.GetAxis("Horizontal") > 0.5)
        {
            steer = steerAngle;
        }
        else if (Input.GetAxis("Horizontal") < -0.5)
        {
            steer = steerAngle * -1;
        }
        else
        {
            steer = 0;
        }

        applySteering(steer);
        //applyDriveForce(driveVertical);
        applyDriveForce(driveForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    // Pushes the car in the vertical direction
    private void applyDriveForce(float torqueToApply)
    {
        if (torqueToApply == 0)
        {
            //backRight.brakeTorque = driveForce;
            //backLeft.brakeTorque = driveForce;
        }
        else
        {
            backRight.motorTorque = torqueToApply;
            backLeft.motorTorque = torqueToApply;
        }
    }


    private void applySteering(float angleToSteer)
    {
        frontRight.steerAngle = angleToSteer;
        frontLeft.steerAngle = angleToSteer;
        //backRight.steerAngle = angleToSteer * -1;
        //backLeft.steerAngle = angleToSteer * -1;
    }
}
