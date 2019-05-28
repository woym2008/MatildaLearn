using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    public int PlaneLife = 3;

    public Transform BornPoint;
    public Transform StartPoint;

    public float PlayerSpeed = 1;

    public float BulletSpeed = 2;

    public Transform EnemyStartPoint_L;
    public Transform EnemyStartPoint_R;

    public float MaxEnemySpeed = 1;
    public float MinEnemySpeed = 0.5f;

    private void Awake()
    {
        var contexts = Contexts.sharedInstance;

        contexts.config.ReplacePlaneConfig(
            PlaneLife,
            BornPoint.position,
            StartPoint.position,
            PlayerSpeed,
            BulletSpeed);

        contexts.config.ReplaceEnemyConfig(
            EnemyStartPoint_L.position,
            EnemyStartPoint_R.position,
            MaxEnemySpeed,
            MinEnemySpeed
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
