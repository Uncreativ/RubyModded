using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatFollow : MonoBehaviour
{
    public Transform mtarget;
    float mSpeed = 3;
    const float Epsilon = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - mtarget.position).magnitude > Epsilon)
        {
            transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
        }
    }
}
