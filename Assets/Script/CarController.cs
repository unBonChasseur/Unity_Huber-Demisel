using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    //private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float currentSteerAngle;
    [SerializeField] private float AngleVolant;
    [SerializeField] private Transform VolantTransform;

    [SerializeField] private int nbTourOriginal;
    [SerializeField] private int nbTourBoiteVitesse;
    [SerializeField] private int niveauBoiteVitesse;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    //[SerializeField] private float verticalInput;

    private void FixedUpdate()
    {
        //GetAngleVolant();

        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetAngleVolant()
    {
        AngleVolant = VolantTransform.transform.eulerAngles.y;
        //currentSteerAngle = AngleVolant;
        if (AngleVolant >= 0 &&  AngleVolant <= 90){
            horizontalInput = AngleVolant / 90;
        }else if(AngleVolant > 270  && AngleVolant < 360){
            horizontalInput = (AngleVolant-360) / 90;   
        }
        
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        //print(horizontalInput)
        //tourMax = 8500;
        switch (niveauBoiteVitesse)
        {
        case 1 :
            
            break;

        case 2 :
            break;

        case 3  :
            break;

        case 4  :
            break;

        case 5  :
            break;

        case 6  :
            break;

        default :
            verticalInput = 0.0f;
            break;              

        }
        verticalInput = Input.GetAxis(VERTICAL);
        //print(verticalInput);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();       
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
