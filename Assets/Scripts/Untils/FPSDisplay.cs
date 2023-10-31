using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    
    [SerializeField] protected TextMeshProUGUI fpsText;
    private float updateInterval = 0.3f;
    private float accum = 0f;
    private int frames = 0;
    private float timeLeft;

    private void Awake()
    {

        this.LoadText();
    }
    protected  void Start()
    {
        if (fpsText == null)
        {
            Debug.LogError("FPS Text UI is not assigned!");
            enabled = false;
            return;
        }

        timeLeft = updateInterval;
    }


    protected virtual void LoadText()
    {
        if (this.fpsText != null) return;
        this.fpsText = GetComponent<TextMeshProUGUI>();
    }

    protected  void Update()
    {
        timeLeft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;

        if (timeLeft <= 0.0)
        {
            float fps = accum / frames;
            string fpsTextString = string.Format("{0:F2} FPS", fps);

            fpsText.text = fpsTextString;

            if (fps < 30)
                fpsText.color = Color.yellow;
            else if (fps < 10)
                fpsText.color = Color.red;
            else
                fpsText.color = Color.green;

            timeLeft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }
}
