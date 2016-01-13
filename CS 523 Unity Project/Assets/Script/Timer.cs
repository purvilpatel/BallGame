using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    float myTimer = 5.0f;
    // Update is called once per frame
    void Update()
    {
        myTimer -= Time.deltaTime;
    }
}
