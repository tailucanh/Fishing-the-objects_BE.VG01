using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : BaseMonoBehaviour
{

    private static BackgroundController instance;
    public static BackgroundController Instance { get => instance; }

    [SerializeField] protected List<Transform> backgroundObjects = new List<Transform>();


    protected override void Awake()
    {
        base.Awake();
        if (BackgroundController.instance != null) Debug.LogError("Only one BackgroundController object exists");
        BackgroundController.instance = this;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBackground();
    }

    protected virtual void LoadBackground()
    {
        if (backgroundObjects.Count > 0) return;
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.CompareTag("BackgroundStart") || childTransform.CompareTag("BackgroundEnd"))
            {
                backgroundObjects.Add(childTransform);
            }
        }
       
    }

    public virtual void OpenBackgroundStart()
    {
        if (backgroundObjects.Count > 0)
        {
            backgroundObjects[0].gameObject.SetActive(true);
            backgroundObjects[1].gameObject.SetActive(false);
        }
    }

    public virtual void OpenBackgroundEnd()
    {
        if (backgroundObjects.Count > 0)
        {
            backgroundObjects[0].gameObject.SetActive(false);
            backgroundObjects[1].gameObject.SetActive(true);
        }
    }


}
