using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthesisSceneController : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        int resultCounter = PlayerPrefs.GetInt("Counter");
        Debug.Log("�ۑ�����Ă���_���F" + resultCounter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
