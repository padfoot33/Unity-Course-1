using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour
{
    public float speed;

    public void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

}