using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoringsystem : MonoBehaviour
{
    public static Scoringsystem Instance;
    public float cherryscore
    {
        get;
        set;
    }
    public int gameplayscore
    {
        get;
        set;
    }
    public TextMeshProUGUI Cherrytext;
    public TextMeshProUGUI Cherrytextfinalscreen;
    public TextMeshProUGUI Gameplayscoretext;
    public TextMeshProUGUI Gameplayscoretextfinalscreen;
    public TextMeshProUGUI highscoretext;
    private void Awake()
    {
        Instance = this;
    }
    public float highscorevalue;
    // Start is called before the first frame update
    void Start()
    {
        Cherrytext.text = cherryscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Incrementcherryscore()
    {
        //increment at savesystem also

        cherryscore += 1;
        Savesystem.Instance.cherryscore = cherryscore;
        Cherrytext.text = cherryscore.ToString();
        //changed
        Cherrytextfinalscreen.text = cherryscore.ToString();
    }
    public void Incrementgameplayscore()
    {
        gameplayscore += 1;
        Gameplayscoretext.text = gameplayscore.ToString();
        //changed
        Gameplayscoretextfinalscreen.text = gameplayscore.ToString();
    }
    public void gameplayscoreset()
    {
        gameplayscore = 0;
        Gameplayscoretext.text = gameplayscore.ToString();

    }
    public void highscore()
    {
        float highscorevalue;
        Savedata savedata = Savesystem.Instance.loadplayervalues();
        if (gameplayscore > savedata.gamplayhighscore)
        {
            highscorevalue = gameplayscore;
            Savesystem.Instance.highscore = highscorevalue;
            Savesystem.Instance.saveplayervalues();

        }
        else
        {
            highscorevalue = savedata.gamplayhighscore;
        }
        highscoretext.text = highscorevalue.ToString();
    }
    //highscore display
}