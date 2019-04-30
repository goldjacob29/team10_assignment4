using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    private bool Fallen;
    // Start is called before the first frame update
    void Start()
    {
        Fallen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < 2 && !Fallen) {
            this.gameObject.AddComponent<TriangleExplosion>();
            StartCoroutine(gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));
            Fallen = true;
        }
    }
}
