using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class ControlPaddle : Agent
{
    [SerializeField] private GameObject leftPaddle;
    [SerializeField] private GameObject rightPaddle;
    [SerializeField] private Transform ballTransfrom;
    [SerializeField] private Animator anim;
    [SerializeField] private Animator anim2;
    private bool isCurrentlyColliding;
    
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(leftPaddle.transform.rotation);
        sensor.AddObservation(rightPaddle.transform.rotation);
        sensor.AddObservation(ballTransfrom.position);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("IsMoved");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.ResetTrigger("IsMoved");
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim2.SetTrigger("IsMoved");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim2.ResetTrigger("IsMoved");
        }
    }

    // public override void OnActionReceived(ActionBuffers actions)
    // {
    //     base.OnActionReceived(actions);
    // }
    //
    // public override void Heuristic(in ActionBuffers actionsOut)
    // {
    //     ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
    //     
    // }
    
    
    
    /*[SerializeField] HingeJoint LeftFlipper;
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
	}*/
}
