using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager
{
    public IEnumerator CoDownloadDataSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(Managers.URL.ExcelURL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        Debug.Log(data);
        Deserialization(data);
    }
    void Deserialization(string data)
    {
        string[] row = data.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;
        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split("\t");
            for (int j = 0; j < columnSize; j++)
            {
                Debug.Log(column[j]);
                // 나중에 int.Parse(column[원하는 인덱스])로 값 넣어주면 됨
            }
        }
    }
}