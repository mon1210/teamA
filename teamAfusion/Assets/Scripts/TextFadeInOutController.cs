using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInOutController : MonoBehaviour
{
    public Text text;

    [SerializeField]
    private GameObject gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Color color=text.material.GetColor("_Color");
        color.a = color.a <= 0 ? 1 : color.a + 0.001f;
        text.material.SetColor("_Color", color);
    }
}
