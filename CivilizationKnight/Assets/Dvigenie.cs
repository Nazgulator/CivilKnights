using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dvigenie : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 2;
    public float TurnSpeed = 60;
    public static float vertical, horizontal;
    Animator Anim;
    void Start()
    {
        Anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * TurnSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
        if (Input.GetAxis("Vertical") < 0) 
        {
            vertical = Input.GetAxis("Vertical") * (MovementSpeed/2) * Time.deltaTime;
        }
        else
        {
            vertical = Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;
        }
        
        transform.Translate(0, 0, vertical);
        if (vertical > 0) { Anim.SetTrigger("Forward"); Anim.SetBool("Walk", true); }
        if (vertical == 0) 
        {
            Anim.SetBool("Walk", false);
        }
        if (vertical < 0) { Anim.SetTrigger("Back"); Anim.SetBool("Walk", true); }
        Anim.SetFloat("Speed",vertical);

        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Atack());
        }

    }

    IEnumerator Atack()
    {

        Anim.SetBool("Atack", true);
        yield return new WaitForSeconds(1);
        Anim.SetBool("Atack", false);

    }
}
