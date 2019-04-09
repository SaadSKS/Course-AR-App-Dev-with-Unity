using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using TMPro;
using System;

public class ARLessons : MonoBehaviour
{
    public GameObject OriginAR;

    //Textmesh Objs
    public GameObject StateTM;
    public GameObject PlanesTM;
    public GameObject PointCloudTM;


    private ARSession ARsession1;
    private ARPlaneManager PM;
    private ARPointCloudManager PCM;

    private int Planes;
    private int PointClouds;

    //UI Text Labels & Values
    private TextMeshProUGUI state;
    private TextMeshProUGUI planes;
    private TextMeshProUGUI pcloud;

    void Start()
    {
        state = StateTM.GetComponent<TextMeshProUGUI>();
        planes = PlanesTM.GetComponent<TextMeshProUGUI>();
        pcloud = PointCloudTM.GetComponent<TextMeshProUGUI>();

        PM = OriginAR.GetComponent<ARPlaneManager>();
        PCM = OriginAR.GetComponent<ARPointCloudManager>();

    }

    

    void Update()
    {
        CheckState();
        ViewPlaneCount();
        CountPoints();
    }
    
    private void ViewPlaneCount()
    {
        Planes = PM.planeCount;
        planes.text = Planes.ToString();
    }

    private void CountPoints()
    {
        PointClouds = GameObject.FindGameObjectsWithTag("Point").Length;
        pcloud.text=PointClouds.ToString();
    }

    private void CheckState()
    {
        switch (ARSubsystemManager.systemState)
        {
            case ARSystemState.CheckingAvailability:
                state.text = "Checking Availability";
                break;

            case ARSystemState.Installing:
                state.text = "Installing";
                break;

            case ARSystemState.NeedsInstall:
                state.text = "Needs Install";
                break;

            case ARSystemState.None:
                state.text = "None";
                break;

            case ARSystemState.Ready:
                state.text = "Ready";
                break;

            case ARSystemState.SessionInitializing:
                state.text = "SessionInitializing";
                break;

            case ARSystemState.SessionTracking:
                state.text = "SessionTracking";
                break;

            case ARSystemState.Unsupported:
                state.text = "Unsupported";
                break;

            default:

                break;

        }
    }

    
}
