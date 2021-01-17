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
        if (Input.GetButton("Fire1"))
        {
            anim.Play("AttaqueMag");
        }

        //Ne fonctionne pas
        if (y != 0 || x != 0)
        {
            anim.SetBool("BoolMarche",true);
        }

    }
}
