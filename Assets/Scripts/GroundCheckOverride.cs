using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;



    public class GroundCheckOverride : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GroundDistance());
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator GroundDistance()
        {
            yield return new WaitForSeconds(.3f);
        }

    }

