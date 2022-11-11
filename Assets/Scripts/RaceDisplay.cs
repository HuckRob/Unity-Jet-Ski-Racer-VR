using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Diagnostics;

public class RaceDisplay : MonoBehaviour
{
    private bool displayedTime = false;
    private bool checkPointOne = false;
    private bool checkPointTwo = false;
    private bool firstLap = true;

    //Storing all the checkpoints
    [SerializeField] private GameObject startFinishCheckPoint;
    [SerializeField] private GameObject secondCheckPoint;
    [SerializeField] private GameObject thridCheckPoint;

    //String all the Text related to the checkpoint
    [SerializeField] private GameObject startFinishCheckPointText;
    [SerializeField] private GameObject bestTimeText;

    Stopwatch lapStopWatch = new Stopwatch();
    Stopwatch bestTime = new Stopwatch();


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == secondCheckPoint.tag)
        {
            UpdateCurrentTimeText(1);
            checkPointOne = true;
            checkPointTwo = false;
        }
        if (other.gameObject.tag == thridCheckPoint.tag && checkPointOne)
        {
            UpdateCurrentTimeText(2);
            checkPointOne = true;
            checkPointTwo = true;
        }
        if (other.gameObject.tag == startFinishCheckPoint.tag && checkPointOne && checkPointTwo)
        {
            checkPointOne = false;
            checkPointTwo = false;
            if(lapStopWatch.Elapsed > bestTime.Elapsed)
            {
                bestTime = lapStopWatch;
            }
            if (firstLap)
            {
                bestTime = lapStopWatch;
                firstLap = false;
            }
            bestTimeText.gameObject.SetActive(true);

            bestTimeText.GetComponent<UnityEngine.UI.Text>().text = "Top Time: " + FormatTime(bestTime).ToString();
            UpdateCurrentTimeText(3);
            lapStopWatch.Restart();
            lapStopWatch.Start();
        }
    }

    private string FormatTime(Stopwatch stopwatch)
    {
        string time;

        int minutes = Mathf.FloorToInt(stopwatch.Elapsed.Minutes);
        int seconds = Mathf.FloorToInt(stopwatch.Elapsed.Seconds);
        time  = string.Format("{0:0}:{1:00}", minutes, seconds);

        return time;
    }

    private void UpdateCurrentTimeText(int currentCheckpoint)
    {
        if (!displayedTime)
        { 
            startFinishCheckPointText.gameObject.SetActive(true);
            displayedTime = true;
        }
        switch (currentCheckpoint)
        {
            case 1:
                //startFinishCheckPointText.GetComponent<UnityEngine.UI.Text>().text = "Checkmark One Time : " + FormatTime(lapStopWatch);
                UnityEngine.Debug.Log("Hit checkmark 1");
                UnityEngine.Debug.Log("Checkmark 1 Time = " + FormatTime(lapStopWatch));
                break;
            case 2:
                //startFinishCheckPointText.GetComponent<UnityEngine.UI.Text>().text = "CheckMark Two Time : " + FormatTime(lapStopWatch);
                UnityEngine.Debug.Log("Hit checkmark 1");
                UnityEngine.Debug.Log("Total Lap time = " + FormatTime(lapStopWatch));
                break;
            case 3:
                startFinishCheckPointText.GetComponent<UnityEngine.UI.Text>().text = "Lap Time : " + FormatTime(lapStopWatch).ToString();
                UnityEngine.Debug.Log("Hit checkmark 1");
                UnityEngine.Debug.Log("Total Lap time = " + lapStopWatch.Elapsed);
                break;
        }
    }

    void Start()
    {
        lapStopWatch.Start();
        bestTimeText.GetComponent<UnityEngine.UI.Text>().text = "";
        startFinishCheckPointText.GetComponent<UnityEngine.UI.Text>().text = "";
    }


    void Update()
    {
        UnityEngine.Debug.Log(FormatTime(lapStopWatch));
        UnityEngine.Debug.Log(lapStopWatch.Elapsed);

    }
}
