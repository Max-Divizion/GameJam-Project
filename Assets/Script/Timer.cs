using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startTime = 60;
    [SerializeField] private Text _timerLable;

    int minutes, seconds;
    string timerStr;

    private void Update()
    {
       _startTime -= Time.deltaTime * 1;
        seconds = (int)(_startTime % 60);
        minutes = (int)(_startTime / 60) % 60;      
        timerStr = string.Format("{0:00}:{1:00}",minutes, seconds);
     

        _timerLable.text = timerStr;
    }
}
