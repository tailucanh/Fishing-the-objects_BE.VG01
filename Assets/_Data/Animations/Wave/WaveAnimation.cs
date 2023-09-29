using UnityEngine;

public class WaveAnimation : AnimationManager
{
  [SerializeField] protected Vector3 initialPosition;
  protected override void Start()
  {
    initialPosition = transform.localPosition;
  }

  protected override void StartAnimation()
  {
    float verticalOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;
    float horizontalOffset = Mathf.Sin(Time.time * horizontalSpeed) * horizontalAmplitude;

    transform.localPosition = initialPosition + new Vector3(horizontalOffset, verticalOffset, 0f);

  }
}
