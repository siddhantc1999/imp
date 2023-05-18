using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgroundrandomize : MonoBehaviour
{
    public List<Material> environments;
    MeshRenderer meshrenderer;
    public int environmentcount;
    // Start is called before the first frame update
    void Start()
    {
        environmentcount = Random.Range(0, environments.Count);
        meshrenderer = GetComponent<MeshRenderer>();
       
        meshrenderer.material= environments[environmentcount];



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
