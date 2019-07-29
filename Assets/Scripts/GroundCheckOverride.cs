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

       
        public IEnumerator GroundDistance()
        {
            yield return new WaitForSeconds(.3f);
        }

    }

