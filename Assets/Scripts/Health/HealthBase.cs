using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 10f;
    public bool destroyOnKill = false;
    public float currentLife;
    public SFXType sfxType;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    public List<UIFillUpdater> uiFillUpdater;

    public float damageMultiply = 1;

    public void Awake()
    {
        Init();
    }


    public void Init()
    {
        float saveLife = SaveManager.Instance.Setup.health;

        if (saveLife > 0)
        {
            currentLife = saveLife;
        }
        else
        {
            ResetLife();
        }
        UpdateUI();
    }

    public void ResetLife()
    {
        currentLife = startLife;
    }

    protected virtual void Kill()
    {
        if (destroyOnKill)
            Destroy(gameObject, 3f);

        OnKill?.Invoke(this);
    }

    public void Damage()
    {
        Damage(5);
    }

    public void Damage(float f)
    {

        currentLife -= f * damageMultiply;
        SFXPool.Instance.Play(sfxType);
        if (currentLife <= 0)
        {
            Kill();
        }
        UpdateUI();
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }

    private void UpdateUI()
    {
        if(uiFillUpdater != null)
        {
            uiFillUpdater.ForEach(i => i.UpdateValue((float)currentLife/startLife));
        }
    }

    public void ChangeDamageMultiply(float damage, float duration)
    {
        StartCoroutine(ChangeDamageMultiplyCoroutine(damageMultiply, duration));
    }

    IEnumerator ChangeDamageMultiplyCoroutine(float damageMultiply, float duration)
    {
        this.damageMultiply = damageMultiply;
        yield return new WaitForSeconds(duration);
        this.damageMultiply = 1;
    }


}
