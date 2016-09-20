using System;
using System.Collections.Generic;
using UnityEngine;

class EnemyManager
{
    private static readonly Dictionary<string, Dictionary<string, int>> enemyStatsDictionary = new Dictionary<string, Dictionary<string, int>>
    {
        {
            NameContainer.ENEMY_KIEBEL,
            new Dictionary<string, int>
            {
                {"Strength", 20},
                {"Points", 10},
            }
        },
        {
            NameContainer.ENEMY_ONE_ERECTION_1,
            new Dictionary<string, int>
            {
                {"Strength", 30},
                {"Points", 20},
            }
        },
        {
            NameContainer.ENEMY_KAYNE,
            new Dictionary<string, int>
            {
                {"Strength", 25},
                {"Points", 15},
            }
        },
    };

    public static void SetProperties(GameObject _gameObject)
    {
        Enemy enemy = _gameObject.GetComponent<Enemy>();

        string enemyName = _gameObject.name.Replace("(Clone)", "");

        if (null == enemy)
        {
            throw new UnityException("Enemy game object does not contain Enemy script.");
        }

        Dictionary<string, int> enemyStats;

        if (enemyStatsDictionary.TryGetValue(enemyName, out enemyStats))
        {
            enemy.Strength = enemyStats["Strength"];
            enemy.Points = enemyStats["Points"];
        }
        else
        {
            throw new UnityException("Enemy: '" + enemyName + "' is not defined in EnemyManager enemyStatsDictionary.");
        }

        
    }

}
