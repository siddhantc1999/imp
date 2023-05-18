using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homescreen : MonoBehaviour
{
    LineRendererManager lineRendererManager;
    // Start is called before the first frame update
    void Start()
    {
        lineRendererManager = FindObjectOfType<LineRendererManager>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void homebuttonclick()
    {
        CanvasManager.Instance.switchscreen(ScreenType.Home);
        lineRendererManager.isgamestarted = false;
        GameManager.Instance.Resetposition();
    }
}
