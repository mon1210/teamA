using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Battler battler;

    public Battler Battler { get => battler;}

    // Start is called before the first frame update
    void Start()
    {
        battler.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
