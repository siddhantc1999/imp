using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool playercanmove=false;
    public Vector3 targetpos;
    public GameObject collidedgameobject = null;
    public bool platformpresent = false;
    float timer = 0f;
    bool istraight = true;
    public bool isplayerdestroyed=false;
    public event Action Targetreachedevent;
    public static PlayerManager Instance;
    public bool delay=false;
    LineRendererManager lineRendererManager;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lineRendererManager = FindObjectOfType<LineRendererManager>();


    }

    void Update()
    {
      
        transform.eulerAngles = Vector3.zero;
        if (playercanmove && !isplayerdestroyed)
        {
            targetpos = new Vector3(targetpos.x, transform.position.y, targetpos.z);
            movetowardstarget(transform.position, targetpos);
            if (transform.position == targetpos )
            {

                if (platformpresent)
                {
                    if (Targetreachedevent != null)
                    {
                        Targetreachedevent();
                        playercanmove = false;
                        platformpresent = false;
                    }
                       
                }
                if (collidedgameobject == null)
                {

                    isplayerdestroyed = true;
                }
            }
            
        }
        if(isplayerdestroyed)
        {
            
            lineRendererManager.linerotatereverse = true;
            Vector3 targetpos;
            Savesystem.Instance.saveplayervalues();
            Scoringsystem.Instance.highscore();
            targetpos = transform.position - Vector3.up * 20f;
            movetowardstarget(transform.position, targetpos);
            if (delay == false)
            {
                delay = true;
                StartCoroutine(Gameoverscreen());
            }
        }
        else
        {
            
            delay =false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (playercanmove && !isplayerdestroyed)
            {
                if (transform.localScale.y == 0.5)
                {
                    istraight = false;
                    transform.localScale = new Vector3(transform.localScale.x, -0.5f, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x, -2.5f, transform.position.z);
                }
                else if (transform.localScale.y == -0.5)
                {
                    istraight = true;
                    transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
                    transform.position = new Vector3(transform.position.x, -1.87f, transform.position.z);
                }
            }
        }
    }

    
    IEnumerator Gameoverscreen()
    {
      
        yield return new WaitForSeconds(2f);
        if (isplayerdestroyed)
        {
            CanvasManager.Instance.Gameover();
        }
        delay = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject != collidedgameobject)
        {
            
            collidedgameobject = collision.collider.gameObject;
            platformpresent = true;
           
        }
        if(collision.gameObject.GetComponent<Blocks>())
        {
            if(!istraight)
            {
                istraight = true;
                 isplayerdestroyed = true;
                playercanmove = false;
        
            }
        }

      
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject != null && playercanmove == false && !isplayerdestroyed)
        {
            targetpos = new Vector3(collision.collider.bounds.max.x - 0.3f, transform.position.y, transform.position.z);
            movetowardstarget(transform.position, targetpos);
            timer += Time.deltaTime;
        }
        

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collidedgameobject = null;
        platformpresent = false;
    }
    
    public void movetowardstarget(Vector3 presentpos,Vector3 targetpos)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetpos, Time.deltaTime * 2f);
    }
    public void changesprite(Sprite sprite)
    {
        
       
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite);
    }


}
