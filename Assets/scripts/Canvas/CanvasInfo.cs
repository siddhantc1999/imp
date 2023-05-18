using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInfo: MonoBehaviour
{
    public ScreenType screentype;
    public Canvas Thiscanvas;
    private void Awake()
    {
        Thiscanvas = transform.GetComponent<Canvas>();
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }


}
