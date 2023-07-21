using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLManager
{
    // 파싱할 JSON 파일의 서버 주소
    public string JsonPath = "https://evenidemonickitchen.s3.ap-northeast-2.amazonaws.com/CouponData.json";
    // 파싱할 Google Excel의 서버 주소
    public string MonsterExcelURL = "https://docs.google.com/spreadsheets/d/1xuE6oeBAJAG2hCicc8MAQDSwpQyPUJ6kXs8Rqdd2q8I/export?format=tsv";
    public string TreeExcelURL = "https://docs.google.com/spreadsheets/d/1f1CuHW1khnSGupcvn6W8HvHLlWQt3dvASy2lzMnpzYs/export?format=tsv";
}
