using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform Player;
    public Vector3 Playeroriginalpos;
    [SerializeField] Transform environment;
    public Vector3 environmentoriginalpos;
    public Vector3 cameraoriginalpos;
    [SerializeField] Transform block1;
    Vector3 blockscale;
    Vector3 playerscale;
    public Vector3 block1pos;
    [SerializeField] Transform block2;
    public Vector3 block2pos;
    [SerializeField] Transform block3;
    public Vector3 block3pos;
    public static GameManager Instance;
    [SerializeField] GameObject defaultcollidedgameobject;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        environmentoriginalpos = environment.transform.position;
        playerscale = Player.transform.localScale;
        cameraoriginalpos = Camera.main.transform.position;
        Playeroriginalpos = Player.transform.position;
        block1pos = block1.position;
        block2pos = block2.position;
        block3pos = block3.position;
        blockscale = block1.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resetposition()
    {
        //put omething in collided gameobject
        PlayerManager.Instance.isplayerdestroyed = false;
        Player.localScale = playerscale;
        PlayerManager.Instance.collidedgameobject = defaultcollidedgameobject;
        PlayerManager.Instance.targetpos = Playeroriginalpos;
        PlayerManager.Instance.playercanmove = false;
        environment.position = environmentoriginalpos;
        Camera.main.transform.position = cameraoriginalpos;
        block1.position = block1pos;
        block1.localScale = blockscale;
        block2.position = block2pos;
        block2.localScale = blockscale;
        block3.position = block3pos;
        block3.localScale = blockscale;
        Player.position = Playeroriginalpos;
        BlockManager.Instance.count = 0;
        BlockManager.Instance.bcount = 0;
        BackgroundManager.Instance.targetpos = cameraoriginalpos;
        Scoringsystem.Instance.gameplayscoreset();
        //Debug.Log(PlayerManager.Instance.collidedgameobject);

    }


    //IEnumerator Reset()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    Debug.Log("here in reset");
    //    Debug.Log(PlayerManager.Instance.collidedgameobject);
    //    PlayerManager.Instance.isplayerdestroyed = false;
    //}
}
