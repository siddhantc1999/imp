using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopplayerdetail : MonoBehaviour
{
    public int Coinsrequired = 3;
    public Spritestate spritestate;
    public GameObject lockedgameobject;
    public GameObject unlockedgameobject;
    public int childindex;
    //public Sprite 
    //locked screen and unlocked screen sprite
    // Start is called before the first frame update
    private void Awake()
    {
        childindex = transform.GetSiblingIndex();
    }
    void Start()
    {
     
       
        
        //here define a func to change the active gameobject
    }

    public void activatesprite()
    {

        if (spritestate == Spritestate.locked)
        {
            lockedgameobject.active = true;
            unlockedgameobject.active = false;
        }
        else if (spritestate == Spritestate.unlocked || spritestate == Spritestate.equipped)
        {

            lockedgameobject.active = false;
            unlockedgameobject.active = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void spriteclicked()
    {
        Shopsystem.Instance.spritebuy(this);
    }
}
public enum Spritestate
{
    locked,
    unlocked,
    equipped
}

