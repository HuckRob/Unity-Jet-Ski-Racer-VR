using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.UI;
using System;

public class RotateToDirection : MonoBehaviour
{
    public enum ControllerType
    {
        None,
        Vive
    }

    public GameObject movingObject;
    private GameObject oldPos;

    private XRController controller = null;
    public ControllerType controllerType = ControllerType.None;


    void Awake()
    {
        controller = GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controller.ToString());
        if(controllerType == ControllerType.Vive) { ViveInput(); }

    }

    private void ViveInput()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondary2DAxis, out Vector2 touch))
        {
            //Debug.Log(touch.ToString());
        }
    }

    private void FixedUpdate()
    {

        
    }
}
