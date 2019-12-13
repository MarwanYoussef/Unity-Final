﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameDmg : MonoBehaviour
{
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 15))
        {
            if (hit.collider)
            {
                print("hitting target " + hit.transform.tag);
                if (hit.transform.tag == "enemyTitan")
                {
                    calculateDamage(hit.collider.gameObject, hit.collider.gameObject.GetComponent<HealthScript>(), "enemyTitan");
                }
                if (hit.transform.tag == "enemyPilot")
                {
                    calculateDamage(hit.collider.gameObject, hit.collider.gameObject.GetComponent<HealthScript>(), "enemyPilot");
                }
                lr.SetPosition(1, hit.point);
            }
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.SetPosition(1, transform.forward*20);
            //lr.SetPosition(0, transform.position);

        }
    }

    void calculateDamage(GameObject enemy, HealthScript enemyHealth, string enemyType)
    {
        if (enemyHealth != null)
        {
            enemyHealth.currentHealth -= 100;
            if (enemyHealth.currentHealth <= 0 && !enemy.GetComponent<Animator>().GetBool("isDead"))
            {
                //if (CoreAbility2.canActiveFlame <= 100)
                //{
                //    if (enemy.gameObject.CompareTag("enemyPilot"))
                //    {
                //        CoreAbility2.canActiveFlame += 10;
                //        print("Impact pilot");
                //    }
                //    else if (enemy.gameObject.CompareTag("enemyTitan"))
                //    {
                //        CoreAbility2.canActiveFlame += 50;
                //        print("impact enemyTitan");
                //    }

                //}

                //if (CoreAbility2.canActiveFlame > 100)
                //{
                //    CoreAbility2.canActiveFlame = 100;
                //}
                //print("Titanfall " + health_and_call_titan_script.titanfallMeter);
                enemy.GetComponent<Animator>().SetBool("isDead", true);
            }

        }
    }
}