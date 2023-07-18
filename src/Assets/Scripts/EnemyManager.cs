using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   public List<Enemy> enemiesTrigger = new List<Enemy> ();


    public void AddEnemy(Enemy enemy)
    {
        enemiesTrigger.Add (enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesTrigger.Remove(enemy);
    }
}
