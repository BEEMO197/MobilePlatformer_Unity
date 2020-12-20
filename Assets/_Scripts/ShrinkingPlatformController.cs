using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformController : MonoBehaviour
{
    public bool isActive;
    public float platformTimer;
    public float inactiveTimer;
    public float threshold;

    public PlayerBehaviour player;

    public Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        
        platformTimer = 0;
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            platformTimer += Time.deltaTime;
            inactiveTimer = 0.0f;
            Shrink();
        }
        else
        {
            inactiveTimer += Time.deltaTime;
            if(inactiveTimer >= 2.5f)
            {
                platformTimer = 0.0f;
                transform.localScale = new Vector3(1.0f, 1.0f, transform.localScale.z);
            }
        }
    }

    private void Shrink()
    {
        float shrinkX = Mathf.Clamp(Mathf.Sin(platformTimer + Mathf.PI / 2), 0.0f, 1.0f);
        float shrinkY = Mathf.Clamp(Mathf.Sin(platformTimer + Mathf.PI / 2), 0.0f, 1.0f);

        if(platformTimer > Mathf.PI)
        {
            shrinkX = 0.0f;
            shrinkY = 0.0f;
        }

        transform.localScale = new Vector3(shrinkX, shrinkY, transform.localScale.z);
        //var shrinkX = (scale.x > 0) ? start.position.x + Mathf.PingPong(platformTimer, scale.x) : 1.0f;
        //var shrinkY = (scale.y > 0) ? start.position.y + Mathf.PingPong(platformTimer, scale.y) : 1.0f;
        //
        //transform.position = new Vector3(distanceX, distanceY, 0.0f);
    }

}
