using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator anim;
    float y = Input.GetAxis("LeftJoystickY");
    float x = Input.GetAxis("LeftJoystickX");

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Lance l'animation Tire
        if (Input.GetButton("TireManette"))
        {
            anim.Play("Attaque");
        }
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            anim.SetBool("MageBoolMarche", true);
            
        }
        else
        {
            anim.SetBool("MageBoolMarche", false);
        }

        if (Input.GetAxis("LeftJoystickX")!=0  || -Input.GetAxis("LeftJoystickY")!=0)
        {
            anim.SetBool("ArcherBoolMarche", true);
        }
        else
        {
            anim.SetBool("ArcherBoolMarche", false);
        }

        //if (Input.GetButton("down"))
        //{
        //    anim.SetBool("Marche",true);
        //}
        if (Input.GetButton("Fire1"))
        {
            anim.Play("AttaqueMag");
            anim.SetBool("BoolMarche", false);
        }

        //Ne fonctionne pas
        if (y != 0 || x != 0)
        {
            anim.SetBool("BoolMarche",true);
        }

    }
}
