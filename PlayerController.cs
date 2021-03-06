using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public FloatingJoyStick floatingJoyStick;
    public FixedJoyStick fixedJoyStick;
    Rigidbody rigidbody;
    public float speed;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        #region FixedJoyStick
        //this.transform.Translate( fixedJoyStick.move.normalized *speed * Time.deltaTime, Space.World);
        rigidbody.velocity = new Vector3(fixedJoyStick.move.x * speed, 0, fixedJoyStick.move.z * speed);
        if (fixedJoyStick.move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(fixedJoyStick.move), 5 * Time.deltaTime);
        }
        #endregion

        #region FloatingJoyStick
        //this.transform.Translate(floatingJoyStick.move.normalized * speed * Time.deltaTime, Space.World);
        rigidbody.velocity = new Vector3(floatingJoyStick.move.x * speed, 0, floatingJoyStick.move.z * speed);

        if (floatingJoyStick.move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(floatingJoyStick.move), 5 * Time.deltaTime);
        }
        #endregion
    }
}

