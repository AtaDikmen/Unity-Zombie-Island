using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDonumu : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(new Vector3(250f, 0, 250f), Vector3.right, 1f * Time.deltaTime);
    }
}
