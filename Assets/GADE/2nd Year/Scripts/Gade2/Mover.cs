using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GADE2
{

    public class Mover : MonoBehaviour
    {
        //public Vector3 UnitsPerSecond = new Vector3(0, 5, 0);
        public float UnitsPerSecond = 5;
        public float MaxHeight = 7f;
        public float MinHeight = 0f;
        public bool Perlin;

        // Start is called before the first frame update
        void Start()
        {
            var pos = transform.position;

            pos.y = Random.Range(MinHeight, MaxHeight);

            transform.position = pos;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var pos = transform.position;

            pos.y += UnitsPerSecond * Time.fixedDeltaTime *
                     (Perlin ? Mathf.PerlinNoise(GetInstanceID(), Time.time) : 1);

            if (pos.y < MinHeight || pos.y > MaxHeight)
                //if (UnitsPerSecond < 0 && pos.y < MinHeight || UnitsPerSecond > 0 && pos.y > MaxHeight)
            {
                UnitsPerSecond *= -1;
            }


            //       pos += UnitsPerSecond * Time.fixedDeltaTime;
            transform.position = pos;
        }
    }
}