using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;


[System.Serializable]
public class Savedata
{
    public float savedcherryscore = 0;
    public float gamplayhighscore = 0;
    //public float playershopno = 0;
    public List<string> spritestatesdata;
    public int currentplayerindex;
   
}
public class Savesystem : MonoBehaviour
{
    public float highscore;
    public float cherryscore;
    public List<string> spritestates;
    Savedata savedata;
    Savedata newsavedata;
    Savedata data;
    public static Savesystem Instance;

    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        savedata = new Savedata();
        savedata = loadplayervalues();
        if (savedata == null)
        {
            savedata.savedcherryscore = 0;
            savedata.gamplayhighscore = 0;
            //here we have toput a conition to let all but one unlocked
            spritestates = new List<string>();

        }
        else
        {
            highscore = savedata.gamplayhighscore;
            cherryscore = savedata.savedcherryscore;
            spritestates = savedata.spritestatesdata;
        }
        Scoringsystem.Instance.cherryscore = cherryscore;
        Scoringsystem.Instance.highscorevalue = highscore;

        FindObjectOfType<Playerlockunlockdetails>().assignlockunlockdetails();
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void saveplayervalues()
    {

        savedata.savedcherryscore = cherryscore;
        savedata.gamplayhighscore = highscore;
        savedata.spritestatesdata = spritestates;
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/debanjan28.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, savedata);
        stream.Close();
    }
    public Savedata loadplayervalues()
    {

        string path = Application.persistentDataPath + "/debanjan28.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            if (stream.Length != 0)
            {

                newsavedata = formatter.Deserialize(stream) as Savedata;
                stream.Close();
                return newsavedata;
            }

        }
        else
        {
            saveplayervalues();
        }

        return savedata;
    }
    public void turnoffequippeddata(int index)
    {

      for(int i=0;i<spritestates.Count;i++)
        {
            if(spritestates[i]==Spritestate.equipped.ToString() && i!=index)
            {
                spritestates[i] = Spritestate.unlocked.ToString(); 
            }
        }
        FindObjectOfType<Playerlockunlockdetails>().assignlockunlockdetails();
    }

}
