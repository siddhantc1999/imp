using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public CanvasInfo[] Canvases;
    public static CanvasManager Instance;
    public Canvas gameoverscreen;
    public CanvasInfo Currentscreen;
    LineRendererManager lineRendererManager;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        /*  PlayerManager.Instance.Targetreachedevent += Gameover;*/
        Canvases = FindObjectsOfType<CanvasInfo>();
        lineRendererManager= FindObjectOfType<LineRendererManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void switchscreen(ScreenType screentype)
    {


        foreach (CanvasInfo screens in Canvases)
        {

            Currentscreen.Thiscanvas.enabled = false;  // getting called teice
            if (screens.screentype == screentype)
            {

                screens.Thiscanvas.gameObject.GetComponent<Canvas>().enabled = true;
                Currentscreen = screens;
                break;
            }
        }

    }
    //if the player losses make the gameover screen appear
    public void Gameover()
    {
        switchscreen(ScreenType.GameOver);
    }
    public void GamePlay()
    {
        switchscreen(ScreenType.GamePlay);
        lineRendererManager.isgamestarted = true;
    }
}
public enum ScreenType
{
    Home,
    GamePlay,
    GameOver,
    PlayerShop
}
