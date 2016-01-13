using UnityEngine;
using System.Collections;

public class RotateCoin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 120, 0) * Time.deltaTime);
    }
}
