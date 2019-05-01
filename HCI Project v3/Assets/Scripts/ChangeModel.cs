using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: https://answers.unity.com/questions/806773/changing-model-during-runtime-after-button-pressed.html

public class ChangeModel : MonoBehaviour
{
    public Mesh modelA;
    public Mesh modelB; 



void Start()
{
     
    }

void Update()
{
    if (gameObject.transform.position.y > 2)
    {
            gameObject.GetComponent<MeshFilter>().mesh = modelA;
    }
        else
        {
            gameObject.GetComponent<MeshFilter>().mesh = modelB;
        }

}
}