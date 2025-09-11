using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData data;
    [SerializeField] private EnemyMovement enemyMovement;    


    //Function cơ bản của Unity
    private void Start()
    {       
        enemyMovement.Setup(data);        
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (enemyMovement != null)        
            enemyMovement.EnemyMove();
            enemyMovement.FlipDirection();        
    }
    // --------------------------------- //
}