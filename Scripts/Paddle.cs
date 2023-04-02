using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class Paddle : Agent
{
    [SerializeField] HingeJoint LeftFlipper;
    [SerializeField] HingeJoint RightFlipper;

    public int FlipperMotorVelocity;
    public int FlipperMotorForce;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RightFlipper.motor = RotateFlipper(FlipperMotorVelocity, FlipperMotorForce);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
        RightFlipper.motor = RotateFlipper(-FlipperMotorVelocity, FlipperMotorForce);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            LeftFlipper.motor = RotateFlipper(-FlipperMotorVelocity, FlipperMotorForce);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
        LeftFlipper.motor = RotateFlipper(FlipperMotorVelocity, FlipperMotorForce);
        }
    }
    JointMotor RotateFlipper(float velocity, float force)
    {
        JointMotor jointMotor = new JointMotor();
        jointMotor.force = force;
        jointMotor.targetVelocity = velocity;
        return jointMotor;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log(actions.DiscreteActions[0]);
	}
}
