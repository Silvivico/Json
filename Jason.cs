using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Jason : MonoBehaviour
{
    public Transform obj1;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            gravar();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ler();
        }
    }



    public void gravar()
    {
        Save s1 = new Save();

        //obj1 = this.GetComponent<Transform>();

        s1.posicao_x = obj1.position.x;
        s1.posicao_z = obj1.position.z;
        s1.posicao_y = obj1.position.y;

        string json = "";

        string filePath = Path.Combine(Application.streamingAssetsPath, "posicao.json");

        print(filePath);

        File.Delete(Application.streamingAssetsPath + "/posicao.json");

        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        json = JsonUtility.ToJson(s1);

      

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
        {
            file.WriteLine(json);
        }


    }

    public void ler()
    {
        try
        {
            string json = System.IO.File.ReadAllText(Application.streamingAssetsPath + "/posicao.json");

            Save s1 = JsonUtility.FromJson<Save>(json);

            obj1.transform.position = new Vector3(s1.posicao_x, s1.posicao_y, s1.posicao_z);
        }
        catch (Exception ex)
        {
            print("Não encontrado");
        }
    }

    public void lerDiretorio()
    {
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath);

        foreach (FileInfo file in di.GetFiles())
        {
            print(file.Name);
        }
    }

    public void apagar()
    {
        File.Delete(Application.streamingAssetsPath + "/.json");
    }
}
