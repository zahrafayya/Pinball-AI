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
    public override void OnEpisodeBegin()
    {
        ballTransfrom.localPosition = new Vector3(0, 3.06f, 0);
    }
    
    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 1)
        {
            SetReward(-5f);
            anim.SetTrigger("IsMoved");
        }
        else anim.ResetTrigger("IsMoved");
        
        if (actions.DiscreteActions[1] == 1)
        {
            SetReward(-5f);
            anim2.SetTrigger("IsMoved");
        }
        else anim2.ResetTrigger("IsMoved");

        Debug.Log("action 1:" + actions.DiscreteActions[0]);
        Debug.Log("action 2:" + actions.DiscreteActions[1]);

    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(leftPaddle.transform.rotation);
        sensor.AddObservation(rightPaddle.transform.rotation);
        sensor.AddObservation(ballTransfrom.position);
    }

    public void Reward()
    {
        SetReward(+1f);
    }
    
    public void Fall()
    {
        EndEpisode();
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            discreteActions[0] = 1;
            Debug.Log("kanan naik");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            discreteActions[0] = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            discreteActions[1] = 1;
            Debug.Log("kiri naik");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            discreteActions[1] = 0;
        }
    }
    
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetReward(-5f);
            anim.SetTrigger("IsMoved");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.ResetTrigger("IsMoved");
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetReward(-5f);
            anim2.SetTrigger("IsMoved");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim2.ResetTrigger("IsMoved");
        }
    }*/


    
    
    
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
