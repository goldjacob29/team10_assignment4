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
        if (player.transform.position.x > 3.21 
            && player.transform.position.x < 5.21
            && player.transform.position.z > 1.79
            && player.transform.position.z < 3.79
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
