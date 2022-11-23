using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    public GameObject boat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            boat.transform.position = new Vector3(player.transform.position.x,0,player.transform.position.z);
        }
    }
}
