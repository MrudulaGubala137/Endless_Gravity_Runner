using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string Name = "Mrudula";
    public int age = 21;
    public float floatValue = 2.8f;
    public string text = "Welcome Text";
    public string filePath = @"C:\Users\Vyshnavi.Gubala\Documents\MyData\SampleFile.txt";
    void Start()
    {
       /*StreamWriter streamWriter = new StreamWriter(filePath);
        //BinaryWriter bw = new BinaryWriter();
        streamWriter.WriteLine(age);
        streamWriter.WriteLine(Name);

        streamWriter.Close();
        
        
        StreamReader streamReader = new StreamReader(filePath);
       //Debug.Log( streamReader.ReadLine());
        Debug.Log(streamReader.ReadToEnd());
        streamReader.Close();
        /*if(File.Exists(filePath))
        {
            using FileStream fileStream = File.Open(filePath, FileMode.Create); // 4
            using BinaryWriter binaryWriter = new(fileStream); // 5
            binaryWriter.Write(age);
           // binaryWriter.Write(Name);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            CreateText();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReadText();
        }
    }
    private void CreateText()
    {

        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        BinaryWriter bw = new BinaryWriter(fileStream);
        bw.Write(age);
        bw.Write(Name);
        bw.Write(floatValue);
        bw.Write(text);
        bw.Close();
        fileStream.Close();
    }
    private void ReadText()
    {

        FileStream fileStream = new FileStream(filePath, FileMode.Open);
        BinaryReader bw = new BinaryReader(fileStream);
      Debug.Log( bw.Read());
    // Debug.Log( bw.ReadString());
        bw.Close();
        fileStream.Close();

    }
}
