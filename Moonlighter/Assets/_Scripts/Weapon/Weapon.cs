using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator Anim { get; private set; }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim.SetBool(WeaponAnimParams.IDLE, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
