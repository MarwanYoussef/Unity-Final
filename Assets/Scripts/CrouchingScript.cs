﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CrouchingScript : MonoBehaviour
{
    Animator anim;

    private RigidbodyFirstPersonController fp_controller;

    public GameObject model;

    // Start is called before the first frame update

    public bool isCrouching = false;

    public CapsuleCollider standingCollider;
    public CapsuleCollider crouchingCollider;

    void Start()
    {
        anim = model.GetComponent<Animator>();
        fp_controller = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Trigger();
            print("Crouch "+isCrouching);
        }

        if(isCrouching && Input.GetKeyDown(fp_controller.movementSettings.RunKey))
        {
            anim.SetBool("isCrouching", false);
            isCrouching = false;
            MovemenetAfterSecond();
        }
    }

    private async void MovemenetAfterSecond()
    {
        await Task.Delay(1000);
        fp_controller.movementSettings.isCrouching = false;
    }

    public void Trigger()
    {
        if (isCrouching)
        {
            anim.SetBool("isCrouching", false);
            isCrouching = false;
            fp_controller.movementSettings.isCrouching = false;

            standingCollider.enabled = true;
            crouchingCollider.enabled = false;
        }
        else
        {
            anim.SetBool("isCrouching", true);
            isCrouching = true;
            fp_controller.movementSettings.isCrouching = true;

            standingCollider.enabled = false;
            crouchingCollider.enabled = true;
        }
    }
}
