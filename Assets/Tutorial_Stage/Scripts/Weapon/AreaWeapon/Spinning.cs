using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningEffect : MonoBehaviour
{
    public float rotateSpeed = 180f;

    private void Update()
    {
        this.transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

    }   

}
