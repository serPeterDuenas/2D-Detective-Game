using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl instance { get; private set; }

    [SerializeField] private Transform player;
    private bool followPlayer = true;
    private void Awake()
    {
        //gatheredAllItems = false;
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer)
        {
            transform.position = new Vector3
                (player.position.x, player.position.y, transform.position.z);
        }
        else
            return;
    }


    public void SetCamera()
    {

        transform.position = new Vector3(0, 0, -10);
        followPlayer = false;
    }
}
