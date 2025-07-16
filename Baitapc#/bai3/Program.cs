public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Nhap ban kinh hinh tron");
        Double r = Convert.ToDouble(Console.ReadLine());
        Double arena = Math.PI * r * r;
        Double cv = Math.PI * r * 2;
        Console.WriteLine("" + arena);
        Console.WriteLine("" + cv);
    }
}
using UnityEngine;
using System.Collections;
using System;
public class AreaPre : MonoBehaviour
{
    
    public float r;
    float area;
    float pre;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         area = Mathf.PI*r*r;
         pre = 2*Mathf.PI*r;
         Debug.Log("Gia tri dien tich"+area);
         Debug.Log("Gia tri chu vi la"+pre); 
    }
    // Update is called once per frame
    void Update()
    {
hsr-kjdm-ppp
