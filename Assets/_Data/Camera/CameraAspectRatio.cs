using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    public SpriteRenderer tagretSize;

    void Start()
    {
        float screenRatiso = (float)Screen.width / (float)Screen.height;
        float tagretRatiso = tagretSize.bounds.size.x / tagretSize.bounds.size.y;
        if(screenRatiso >= tagretRatiso)
        {
            Camera.main.orthographicSize = tagretSize.bounds.size.y / 2;
        }else
        {
            float differenceInSize = tagretRatiso / screenRatiso;
            Camera.main.orthographicSize = tagretSize.bounds.size.y / 2 * differenceInSize;
        }
    }

    // Update is called once per frame
   
}
