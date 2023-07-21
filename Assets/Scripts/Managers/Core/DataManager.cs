using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager
{
    public List<float> MonsterData = new List<float>();
    public List<float> TreeData = new List<float>();
    public List<float> TurretData = new List<float>();
    public IEnumerator CoDownloadMonsterDataSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(Managers.URL.MonsterExcelURL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        Debug.Log(data);
        Deserialization(data, MonsterData);
        // TODO
        Managers.Game.LoadCompleted = true;
    }
    public IEnumerator CoDownloadTreeDataSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(Managers.URL.TreeExcelURL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        Debug.Log(data);
        Deserialization(data, TreeData);
    }
    public IEnumerator CoDownloadTurretDataSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(Managers.URL.TurretExcelURL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        Debug.Log(data);
        Deserialization(data, TurretData);
    }
    void Deserialization(string data, List<float> datas)
    {
        string[] row = data.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;
        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split("\t");
            for (int j = 0; j < columnSize; j++)
            {
                //Debug.Log(column[j]);
                int value;
                bool isInt = int.TryParse(column[j], out value);
                if (isInt)
                    datas.Add(value);
                else
                    datas.Add(-1);
            }
        }
    }
}