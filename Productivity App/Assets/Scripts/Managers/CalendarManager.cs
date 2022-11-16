using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum Month
{
    January,February,March,April,May,June,July,August,September,October,November,December
}



public class CalendarManager : MonoBehaviour
{

    private Dictionary<int, string> dayStringDict = new Dictionary<int, string>()
    {
        { 0, "Sun" },
        { 1, "Mon" },
        { 2, "Tue" },
        { 3, "Wed" },
        { 4, "Thur" },
        { 5, "Fri" },
        { 6, "Sat" },
    };
    [SerializeField] private GameObject calendar;
    [SerializeField] private GameObject date;
    [SerializeField] private TMP_Text month;
    public Month m=0;
    
    // Start is called before the first frame update
    void Start()
    {
DisplayCalendar();    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int CalculateCalendar(int d,int m,int y)
    {
        if (m == 1) m = 11;
        else if (m == 2) m = 12;
        else m = m - 2;
        int k = d;
        int D = y % 100;
        y /= 100;
        int C = y % 100;
        int F= k + (13*m-1)/5 +D+ (D/4) +(C/4)-2 * C;
        if(F>=0)d = F % 7;
        else 
        {
            d = F % 7;
            d = 7 + d;
        }

        return d;
    }

    void DisplayCalendar( )
    {
        month.text = m.ToString();

        int o = 0;
        if (Month.February == m) o = 28;
        else
        {
            int a = (int)m;
            if ((a+1)% 2==0) o = 30;
            else o = 31;
        }
            //create all those day objects
            for (int i = 1; i <= o; i++)
            {
                Instantiate(date, calendar.transform);
                string today = dayStringDict[CalculateCalendar(i, (int)m+1, 2022)];
                date.GetComponent<Date>().day.text = ""+i;
                date.GetComponent<Date>().dayName.text = today;
                
            }
        //assign a day, number to each of them
        
        
    }

    public void DisplayCal(int a)
    {
        if (m == Month.January && a==-1)
        {
            m = Month.December;
        }
        else if (m == Month.December && a == 1)
        {
            m = Month.January;
        }
        else
            m += a;
        
        int nbChildren = calendar.transform.childCount;

        for (int i = nbChildren - 1; i >= 0; i--) {
            DestroyImmediate(calendar.transform.GetChild(i).gameObject);
        }
        DisplayCalendar();
    }
}
