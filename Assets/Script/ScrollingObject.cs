using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Transform tr;
    public float Speed = 10f;
    void Start()
    {
        tr = GetComponent<Transform>();
    }
    void Update()
    {
        if(!GameManager.instance.isGameOver)
            tr.Translate(Vector3.left * Speed * Time.deltaTime);
    }
}