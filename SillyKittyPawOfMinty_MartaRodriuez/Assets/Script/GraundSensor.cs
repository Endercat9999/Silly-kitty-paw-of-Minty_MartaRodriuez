using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraundSensor : MonoBehaviour
{
    public bool isGrounded;
    public Animator anim;
    gato_menta playerScript;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInParent<Animator>();
        playerScript = GetComponentInParent<gato_menta>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
