using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class PiChartManager : MonoBehaviour
{

    public Image[] charts;
    public float[] values;

    public static PiChartManager main;

    private void Awake()
    {
        main = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateCharts()
    {
        
    }

    public void SetValue(float[] valuesToSet)
    {
        float totalValues = 0;

        for (int i = 0; i < charts.Length; i++)
        {
            totalValues += FindPercentage(valuesToSet, i);
            charts[i].fillAmount = totalValues;
        }
    }

    public float FindPercentage(float[] valueToSet,int index)
    {
        float totalAmount = 0;
        for (int i = 0; i < valueToSet.Length; i++)
        {
            totalAmount += valueToSet[i];
        }
        return valueToSet[index]/totalAmount;
    }
}
