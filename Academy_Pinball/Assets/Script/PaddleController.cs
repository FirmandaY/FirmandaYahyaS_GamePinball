using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    private float targetPressed;
    private float targetRelease;
    private HingeJoint hinge;
    public float springPower;

    // Start is called before the first frame update
    void Start()
    {
        // hinge joint disimpan saat start terlebih dahulu
        hinge = GetComponent<HingeJoint>();
        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        //Read Input
        ReadInput();
        //Move Paddle
        //MovePaddle();

    }

    private void ReadInput()
    {
        // mengambil spring dari component Hinge joint
        JointSpring jointSpring = hinge.spring;

        // mengubah value spring saat input ditekan dan dilepas
        if (Input.GetKey(input))
        {
            //Debug.Log("Dipencet hore!");
            jointSpring.targetPosition = targetPressed;
        }
        else
        {
            jointSpring.targetPosition = targetRelease;
        }

        // mengubah spring pada Hinge Joint dengan value yang sudah di ubah
        hinge.spring = jointSpring;
    }

    private void MovePaddle()
    {

    }
}
