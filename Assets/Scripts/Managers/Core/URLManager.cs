using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLManager
{
    // 파싱할 JSON 파일의 서버 주소
    public string JsonPath = "https://evenidemonickitchen.s3.ap-northeast-2.amazonaws.com/CouponData.json";
    // 파싱할 Google Excel의 서버 주소
    public string ExcelURL = "https://docs.google.com/spreadsheets/d/15rqyXR509ffPJByFT7KADlavB6cqdq79Uip5MvbCvjE/export?format=tsv";
}
