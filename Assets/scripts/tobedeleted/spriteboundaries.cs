using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteboundaries : MonoBehaviour
{
    SpriteRenderer myspriterenderer;
    /*   public Vector3 threshold;*/
    /* public Vector3 size;*/
    PolygonCollider2D mypolygoncollider2d;
    /* public Vector3 centre;*/
    public Vector3 xmin;
    public Vector3 xmax;
    public Vector3 toposition;
    public Vector3 differencevector;
    public float timer = 0;
    public float perc = 0f;
    // Start is called before the first frame update
    void Start()
    {
        myspriterenderer = GetComponent<SpriteRenderer>();
        mypolygoncollider2d = GetComponent<PolygonCollider2D>();


        xmin = mypolygoncollider2d.bounds.min;
        xmax = mypolygoncollider2d.bounds.max;
        toposition = new Vector3(xmin.x, xmax.y, 0f);
        //differencevector = toposition - Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        /* timer += Time.deltaTime;*/
        Debug.DrawLine(Vector3.zero, toposition, Color.red);


    }
}
