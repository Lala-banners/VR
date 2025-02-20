﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    #region enum
    public enum RotationAxis
    {
        MouseH,
        MouseV,
    }
    #endregion
    #region Variables
    [Header("Rotation Variables")]
    public RotationAxis axis = RotationAxis.MouseH;
    [Range(0, 200)]
    public float sensitivity = 100;
    public float minY = -60, maxY = 60;
    private float _rotY;
    #endregion
    #region Start
    private void Start()
    {
        //Freeze the rigidbody so it doesnt fall over
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
     
        if (GetComponent<Camera>())
        {
            axis = RotationAxis.MouseV;
        }
    }
    #endregion
    #region Update
    private void Update()
    {
        //Horizontal Looking
        if (axis == RotationAxis.MouseH)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime, 0);
        }
        //Vertical looking
        else
        {
            // Maximum and minimum vertical look angle
            _rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            _rotY = Mathf.Clamp(_rotY, minY, maxY);


            transform.localEulerAngles = new Vector3(-_rotY,0,0);

        }
    }
    #endregion
}
