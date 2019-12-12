﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveAbility2 : MonoBehaviour
{
    private Animator anim;
    public GameObject thermalSheild;
    private bool canActiveSheild = true;
    // Start is called before the first frame update
    IEnumerator waitEightSeconds(){
        yield return new WaitForSeconds(8f);
        
        thermalSheild.gameObject.SetActive(false);
        //anim.SetBool("onDefClick", false);
    }
    IEnumerator waitFifteenSeconds(){
        yield return new WaitForSeconds(15f);
        canActiveSheild = true;
    }
    
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canActiveSheild)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                thermalSheild.gameObject.SetActive(true);
                StartCoroutine(waitEightSeconds());
                canActiveSheild = false;
                StartCoroutine(waitFifteenSeconds());
            }
        }
    }
}
