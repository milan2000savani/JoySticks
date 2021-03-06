using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public FloatingJoyStick floatingJoyStick;
    public FixedJoyStick fixedJoyStick;

    

    // Update is called once per frame
    void Update()
    {
        #region FixedJoyStick
        this.transform.Translate( fixedJoyStick.move.normalized *fixedJoyStick.moveSpeed * Time.deltaTime, Space.World);

        if (fixedJoyStick.move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(fixedJoyStick.move), 5 * Time.deltaTime);
        }
        #endregion

        #region FloatingJoyStick
        this.transform.Translate(floatingJoyStick.move.normalized * 5 * Time.deltaTime, Space.World);

        if (floatingJoyStick.move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(floatingJoyStick.move), 5 * Time.deltaTime);
        }
        #endregion
    }
}

