using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{

    public GunBase gunBase;
    public Transform gunPostion;

    private GunBase _currentGun;
    public FlashColor _flashColor;

    protected override void Init()
    {
        base.Init();

        CreateGun();

        inputs.GamePlay.Shoot.performed += ctx => StartShoot();
        inputs.GamePlay.Shoot.performed += ctx => CancelShoot();
    }

    private void CreateGun()
    {
        _currentGun = Instantiate(gunBase, gunPostion);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    public void TradeGun(GunBase newGunBase)
    {
        gunBase = newGunBase;
        CreateGun();
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        _flashColor?.Flash();
        Debug.Log("Shoot");
    }

    private void CancelShoot()
    {
        Debug.Log("cancel Shoot");
        _currentGun.StopShoot();
    }
}
