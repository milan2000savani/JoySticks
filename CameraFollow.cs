using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject Player;
    Vector3 offSet;
    // Start is called before the first frame update
    void Start()
    {
        offSet = Player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = (Player.transform.position - offSet);
    }
}
