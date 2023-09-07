using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject[] Button = new GameObject[1];
    public bool[] isSelect = new bool[1];
    [SerializeField] Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButton()
    {
        isSelect[0] =! isSelect[0];

        SceneManager.LoadScene("ChoiceScene");
    }
}
