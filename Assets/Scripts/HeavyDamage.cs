﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
        GameObject[] enemyPilots = GameObject.FindGameObjectsWithTag("enemyPilot");
        GameObject[] enemyTitans = GameObject.FindGameObjectsWithTag("enemyTitan");
        foreach(GameObject enemyPilot in enemyPilots)
        {
            if (Vector3.Distance(transform.position, enemyPilot.transform.position) <= WeaponManager.heavyRange)
            {
                EnemyStats enemyStats = enemyPilot.GetComponent<EnemyStats>();
                calculateDamage(enemyPilot, enemyStats, "enemyPilot");
            }
        }
        foreach (GameObject enemyTitan in enemyTitans)
        {
            if (Vector3.Distance(transform.position, enemyTitan.transform.position) <= WeaponManager.heavyRange)
            {
                EnemyStats enemyStats = enemyTitan.GetComponent<EnemyStats>();
                calculateDamage(enemyTitan, enemyStats, "enemyTitan");
            }
        }
           gameObject.SetActive(false);
        }
    }

    void calculateDamage(GameObject enemy, EnemyStats enemyStats, string enemyType)
    {
        if (enemyStats != null)
        {
            enemyStats.health -= WeaponManager.heavyDamage;
            if (enemyStats.health <= 0)
            {
                if (Stats.titanFall <= 100)
                {
                    if (health_and_call_titan_script.titanfallMeter <= 100)
                    {
                        if (enemyType == "enemyPilot")
                        {
                            health_and_call_titan_script.titanfallMeter += 10;
                        }
                        else if (enemyType == "enemyTitan")
                        {
                            health_and_call_titan_script.titanfallMeter += 50;
                        }
                        print("Titanfall " + Stats.titanFall);

                    }

                    if (health_and_call_titan_script.titanfallMeter > 100)
                    {
                        health_and_call_titan_script.titanfallMeter = 100;
                    }
                    print("Titanfall " + Stats.titanFall);

                }
                enemy.SetActive(false);
            }

        }
    }
}