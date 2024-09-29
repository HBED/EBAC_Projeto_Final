using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour
{
    public HealthBase healthBase;

    public float shakeDuration = .2f;
    public int shakeForce = 1;

    public int dropCoinnsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    // Start is called before the first frame update
    void Start()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;
    }

    private void OnDamage(HealthBase h)
    {
        gameObject.transform.DOShakeScale(shakeDuration, Vector3.up/2, shakeForce);
        DropCoins();
    }

    private void DropCoins()
    {
        var i = Instantiate(coinPrefab);

        i.transform.position = dropPosition.position;
        i.transform.DOScale(0, 1.5f).SetEase(Ease.OutBack).From();
    }


    private void DropGroupOfCoins()
    {
        StartCoroutine(DropGroupOfCoinsCoroutine());
    }

    IEnumerator DropGroupOfCoinsCoroutine()
    {
        for (int i = 0; i < dropCoinnsAmount; i++)
        {
            DropCoins();
            yield return new WaitForSeconds(.1f);
        }
    }
}
