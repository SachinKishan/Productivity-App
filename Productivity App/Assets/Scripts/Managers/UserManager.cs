using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.U2D.Animation;

public class UserManager : MonoBehaviour
{
    [SerializeField] UserData _userData;
    [SerializeField] public DailyActivity[] activities;
    [SerializeField] public Task[] tasks;
    /*
     *total score
     * task list data
     * daily activity data
     * user name
     * 
     * keep this for later-vscore achieved in a day- reset after 24 hours
     * 
     */
    // Start is called before the first frame update

    public static UserManager main;

    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        //SaveScore();
        //SaveData();
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore()
    {
        string j = JsonUtility.ToJson(_userData);
        Debug.Log(j);
    }

    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string j = JsonUtility.ToJson(_userData);
        string path = Application.persistentDataPath + "/UserData.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, j);
        stream.Close();
        
        formatter = new BinaryFormatter();
        string tasktoJson = JSONHelper.ToJson(tasks, true);
        path = Application.persistentDataPath + "/tasks.dat";
        FileStream stream2 = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream2, tasktoJson);
        stream2.Close();
        
        formatter = new BinaryFormatter();
        string actstoJson = JSONHelper.ToJson(activities, true);
        path = Application.persistentDataPath + "/acts.dat";
        FileStream stream3 = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream3, actstoJson);
        stream3.Close();

        
        Debug.Log("done");
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/UserData.dat";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            string data = formatter.Deserialize(stream) as string;
            UserData us = (UserData)JsonUtility.FromJson(data,typeof(UserData));
            
            stream.Close();
            if (us!=null)
            {
                _userData.totalScore = us.totalScore;
                _userData.username = us.username;
              
               
            }
        } else
        {
            Debug.LogError("Error: Save file not found in " + path);
        }
        
        
        path = Application.persistentDataPath + "/tasks.dat";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            string data = formatter.Deserialize(stream) as string;
            Task[] t = JSONHelper.FromJson<Task>(data);
            tasks = new Task[t.Length];
            t.CopyTo(tasks,0);
            stream.Close();
            
        } else
        {
            Debug.LogError("Error: Save file not found in " + path);
        }
        
        path = Application.persistentDataPath + "/acts.dat";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            string data = formatter.Deserialize(stream) as string;
            DailyActivity[] a = JSONHelper.FromJson<DailyActivity>(data);
            activities = new DailyActivity[a.Length];
            a.CopyTo(activities,0);
            stream.Close();
            
        } else
        {
            Debug.LogError("Error: Save file not found in " + path);
        }
        
        
    }

    public void AddTask(Task a)
    {
        Task[] b = tasks;
        tasks = new Task[tasks.Length+1];
        b.CopyTo(tasks,0);
        tasks[tasks.Length - 1] = a;
    }

    public void AddAct(DailyActivity a)
    {
        DailyActivity[] b = activities;
        activities = new DailyActivity[activities.Length+1];
        b.CopyTo(activities,0);
        activities[activities.Length - 1] = a;
    }
}
