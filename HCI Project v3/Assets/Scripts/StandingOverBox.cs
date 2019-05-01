using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingOverBox : MonoBehaviour
{

    private Animator Snowman_Animator;
    private GameObject player;
    private bool Entered;


    // Start is called before the first frame update
    void Start()
    {
        Snowman_Animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        Entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > -0.5 
            && player.transform.position.x < 1.5
            && player.transform.position.z > -.85
            && player.transform.position.z < 1.15
           ) {
            Snowman_Animator.ResetTrigger("NoLongerStanding");
            Entered = true;
            Snowman_Animator.SetTrigger("Standing");
        } else {
            if (Entered) {
                Snowman_Animator.ResetTrigger("Standing");
                Snowman_Animator.SetTrigger("NoLongerStanding");
            }

        }

    }
}
