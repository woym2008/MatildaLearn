using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个脚本为游戏核心脚本
//各个管理器依赖这个脚本作为入口，进行初始化和轮询
public class EntranceController : MonoBehaviour
{
    private void Awake()
    {
        GameManager.getInstance.GameInit();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.getInstance.GameUpdate();


        //test
        if (!GameManager.getInstance.IsGameStart && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.getInstance.GameStart();
        }
    }
}
