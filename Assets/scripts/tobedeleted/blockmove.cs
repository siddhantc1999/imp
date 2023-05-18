using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmove : MonoBehaviour
{
    
    public Vector3 targetpos;
    bool canstartmove;
    
    // Start is called before the first frame update
    void Start()
    {
        targetpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position!=targetpos)
        {
            transform.position = Vector3.MoveTowards(transform.position,targetpos,Time.deltaTime*2f);
        }
        

    }
    
}
