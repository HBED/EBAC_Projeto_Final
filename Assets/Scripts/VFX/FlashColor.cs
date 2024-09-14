using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    [Header("Setup")]
    public Color color = Color.red;
    public float duration = .1f;

    private Color defaultColor;

    private Tween _currTween;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = meshRenderer.material.GetColor("_EmissionColor");
    }

    public void Flash()
    {
        if (!_currTween.IsActive())
            _currTween = meshRenderer.material.DOColor(color, "_EmissionColor",duration).SetLoops(2, LoopType.Yoyo);
    }

}
