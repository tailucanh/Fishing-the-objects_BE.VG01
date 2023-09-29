using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Start()
    {

    }
    protected virtual void Update()
    {

    }
    protected virtual void Reset()
    {
        this.LoadComponents();
    }


    protected virtual void LoadComponents()
    {
        // For override
    }
}
