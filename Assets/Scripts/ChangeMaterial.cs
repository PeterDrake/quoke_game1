using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public GameObject yourObject;
    float timer;
    bool highlighted;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer > 0.5) {
            timer = 0;
            if (highlighted) {
                yourObject.GetComponent<MeshRenderer>().material = material1;
                highlighted = false;
            }
            else {
                yourObject.GetComponent<MeshRenderer>().material = material2;
                highlighted = true;
            }
        }
    }
}

                