using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    //[SerializeField] private Transform zeroPosition;
    //private bool followPlayer = true;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // if (followPlayer)
        // {/
        transform.position = new Vector3
            (player.position.x, player.position.y, transform.position.z);
        //}

        // if(Input.GetKeyDown("f"))
        //if(GameManager.instance.gatheredAllItems)
        //{
        //    followPlayer = false;
        //   transform.position = new Vector3(0, 0, -10);

        //(transform.position.x, zeroPosition.position.y, zeroPosition.position.z);
        //}
    }
}
