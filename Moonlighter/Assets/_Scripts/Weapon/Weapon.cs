using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator Anim { get; private set; }
    public AnimationHandler AnimHandler { get; private set; }

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        AnimHandler = GetComponent<AnimationHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim.SetBool(WeaponAnimParamsToHash.IDLE, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
