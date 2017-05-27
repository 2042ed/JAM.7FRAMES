using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JAMURR
{
    public class Butterfly : MonoBehaviour
    {
        Vector3 target;
        float timer;
        int sec;

        float moveSpeed = 0.1f;

        float origX;
        float origY;

        float maxX = 1f;
        float minX = -1f;
        float maxY = 1f;
        float minY = -1f;

        void Start()
        {
            target = ResetTarget();
            sec = ResetSec();

            //origX = transform.position.x;
            //origY = transform.position.y;
        }

        void Update()
        {
            timer += Time.deltaTime;
            if (timer > sec) {
                target = ResetTarget();
                sec = ResetSec();
            }
            transform.Translate(target * moveSpeed * Time.deltaTime);
        }

        Vector3 ResetTarget()
        {
            return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        }

        int ResetSec()
        {
            timer = 0;
            return Random.Range(1, 3);
        }

    }
}