using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private int filledSlots = 0;

    public static PuzzleManager instance { get ; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
