using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TaskAdder : MonoBehaviour
{

    [SerializeField] private TextField tfName;
    [SerializeField] private TextField tfDay;
    [SerializeField] private TextField tfMonth;
    [SerializeField] private TextField tfHour;
    [SerializeField] private TextField tfMin;
    [SerializeField] public bool AM;
    [SerializeField] private TextField tfScore;
    private int year = 2022;    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTheTask()
    {
        Task t= new Task();
        t.day = Int32.Parse(tfDay.value); 
        t.month = Int32.Parse(tfMonth.value); 
        t.min = Int32.Parse(tfMin.value); 
        t.hour = Int32.Parse(tfHour.value); 
        t.score = Int32.Parse(tfScore.value);
        t.year = year;
        UserManager.main.AddTask(t);
    }

    public void setAM(bool setit)
    {
        AM = setit;
    }
}
