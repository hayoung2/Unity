using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private SpriteRenderer frontCardRenderer;
    private SpriteRenderer backCardRenderer;

    private AudioSource effector;
    private bool isEnable = false;

    public Color CardColor
    {
        get => backCardRenderer.color;
        set => backCardRenderer.color = value;
    }

    //  유니티 플로우차트
    private void Awake()
    {
        frontCardRenderer = GetComponent<SpriteRenderer>();
        backCardRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        effector = GetComponent<AudioSource>();
    }

}
