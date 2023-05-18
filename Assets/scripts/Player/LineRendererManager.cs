using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LineRendererManager : MonoBehaviour
{
    public LineRenderer linerenderer;
    public Vector3 currentposition;
    public float mindistance;
    public EdgeCollider2D edgecollier2d;
    public List<Vector2> positions;
    public float angle;
    float timer = 0f;
    public bool linerotate = false;
    float percmoved;
    [SerializeField] GameObject player;
    public float yminsprite;
    //playermovement myplayermovement;
    PlayerManager playerManager;
    public Vector3 targetpos;
    public float length;
    public BoxCollider2D boxcollider2d;
    public LineController linecontroller;
    bool stoplinestretch = true;
    public bool linestretch = false;
    public bool isgamestarted;
    public bool linerotatereverse=false;
    float threshold;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        linecontroller = new LineController();
        isgamestarted = false;
        playerManager = FindObjectOfType<PlayerManager>();
        linerenderer.SetWidth(0.1f, 0.1f);
        yminsprite = player.GetComponent<SpriteRenderer>().bounds.min.y;
        currentposition = Vector3.zero;
        linerotate = false;
        linecontroller.Enable();
      
        linecontroller.LineControl.touchcontrol.started += ontouchdown;
        linecontroller.LineControl.mousecontrol.started += ontouchdown;
        linecontroller.LineControl.touchcontrol.performed += ontouch;
        linecontroller.LineControl.mousecontrol.performed += ontouch;
        linecontroller.LineControl.touchcontrol.canceled += ontouchup;
        linecontroller.LineControl.mousecontrol.canceled += ontouchup;


    }

    // Update is called once per frame
    void Update()
    {
        if (!linerotate && !playerManager.playercanmove && !playerManager.isplayerdestroyed)
        {
          
            stoplinestretch = true;
        }
        else
        {
            
            stoplinestretch = false;
        }
        if (linestretch == true)
        {
            DrawLine();
        }
        Linerotate();
    }

    private void Linerotate()
    {
        if (linerotate)
        {

            angle = Vector3.Angle(player.transform.up, player.transform.right);
            percmoved = Mathf.MoveTowards(0f, angle, timer * 100f);
            timer += Time.deltaTime;
            linerenderer.transform.eulerAngles = new Vector3(0f, 0f, -percmoved);
            if (linerenderer.transform.eulerAngles.z == 270f)
            {


                playerManager.playercanmove = true;
               
                linerotate = false;
                timer = 0f;
                if (positions.Count > 1)
                {
                    playerManager.targetpos = new Vector3(player.transform.position.x + positions[positions.Count - 1].y + 0.25f, player.transform.position.y, player.transform.position.z);
                    boxcollider2d.transform.position = new Vector3(transform.position.x + positions[positions.Count - 1].y, transform.position.y, player.transform.position.z);
                }
            }

        }
        if (linerotatereverse)
        {
            if (length > 5f)
            {
                threshold = 270f;
            }
            else
            {
                threshold = 180f;
            }
            if (linerenderer.transform.eulerAngles.z != threshold)
            {
                
                angle = Vector3.Angle(player.transform.up, player.transform.right);
                percmoved = Mathf.MoveTowards(270, 180, timer * 100f);
                timer += Time.deltaTime;
                linerenderer.transform.eulerAngles = new Vector3(0f, 0f, percmoved);
                if (linerenderer.transform.eulerAngles.z == 180)
                {
                    linerotatereverse = false;
                    timer = 0f;
                }
            }
            else

            {
               
                linerotatereverse = false;
            }
        }
    }

    public void ontouchdown(InputAction.CallbackContext context)
    {
      
        if (stoplinestretch && isgamestarted)
        {
           
            StartDrawLine();
        }
    }
    public void ontouch(InputAction.CallbackContext context)
    {
        if (stoplinestretch && isgamestarted)
        {
           
            linestretch = true;
        }
    }
    public void ontouchup(InputAction.CallbackContext context)
    {
        if (stoplinestretch && isgamestarted)
        {
            linestretch = false;
            linerotate = true;
        }
    }
    public void StartDrawLine()
    {
        positions.Clear();


        transform.position = new Vector3(player.transform.position.x + 0.25f, yminsprite, 0f);
        linerenderer.SetPosition(0, Vector3.zero);
        linerenderer.SetPosition(1, Vector3.zero);
        linerenderer.transform.eulerAngles = Vector3.zero;
        currentposition = Vector3.zero;
        linerenderer.SetPosition(0, currentposition);
    }
    public void DrawLine()
    {
        length = linerenderer.GetPosition(1).y - linerenderer.GetPosition(0).y;
        if (length <= 5f)
        {
            currentposition += (player.transform.up * 1.5f * Time.deltaTime);
            currentposition = new Vector3(0f, currentposition.y, 0f);
            if (linerenderer.positionCount <= 1)
            {

                linerenderer.positionCount++;
            }

            positions.Add(new Vector2(currentposition.x, currentposition.y));
            linerenderer.SetPosition(1, currentposition);
            edgecollier2d.points = positions.ToArray();
        }
        else
        {
            if (linerenderer.transform.eulerAngles.z != 270f)
            {
                linerotate = true;
            }
        }
    }

}
