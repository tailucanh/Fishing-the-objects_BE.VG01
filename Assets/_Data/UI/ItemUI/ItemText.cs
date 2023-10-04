using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemText : BaseMonoBehaviour
{
    protected static ItemText instance;
    public static ItemText Instance => instance;

    [SerializeField] TextMeshProUGUI textItem;
    [SerializeField] Image bgBlur;
    protected string itemName;
    private bool isShowing = false;

    protected override void Awake()
    {
        if (ItemText.instance != null) return;
        ItemText.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        itemName = "";
    }

    protected override void Update()
    {
        Debug.Log("isShowing: " + isShowing);
       
       
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextMes();
        this.LoadBgBlur();
    }

    protected virtual void LoadTextMes()
    {
        if (this.textItem != null) return;
        this.textItem = GetComponentInChildren<TextMeshProUGUI>();
    }
    protected virtual void LoadBgBlur()
    {
        if (this.bgBlur != null) return;
        this.bgBlur = GetComponentInChildren<Image>();
    }


    public void ShowItemText(string itemName)
    {
        if (!string.IsNullOrEmpty(itemName) && !isShowing)
        {
            this.itemName = itemName;
            StartCoroutine(DelayShowText());
        }

    }
    private IEnumerator DelayShowText()
    {
        isShowing = true;
        yield return new WaitForSeconds(5.5f);

        if (isShowing) 
        {
            this.textItem.gameObject.SetActive(true);
            this.bgBlur.gameObject.SetActive(true);
            this.textItem.text = itemName;

            yield return new WaitForSeconds(2f);

            this.textItem.gameObject.SetActive(false);
            this.bgBlur.gameObject.SetActive(false);
            itemName = "";
            isShowing = false;
        }
    }

}
