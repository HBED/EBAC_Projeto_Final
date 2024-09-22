using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour//, IDamageable
{
    public PlayerSM playerSM;
    public Animator animator;
    public List<Collider> colliders;


    public ParticleSystem jetParticles;
    public PlayerAbilityShoot playerAbilityShoot;

    public List<GunBase> gunInvetory;

    public CharacterController characterController;
    public float speed = 2f;
    public float turnSpeed = 2f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15f;
    public float speedRun = 1.5f;
    public float jetSpeed = 3f;

    private float vSpeed = 0f;
    public KeyCode jumpKeyCode = KeyCode.Space;
    public KeyCode runKeyCode = KeyCode.R;
    public KeyCode jetKeyCode = KeyCode.G;
    public KeyCode gun1KeyCode = KeyCode.Alpha1;
    public KeyCode gun2KeyCode = KeyCode.Alpha2;
    private bool _alive = true;

    [Header("Flash")]
    public List<FlashColor> FlashColors;

    public HealthBase healthBase;

    int timeJet = 0;

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += Damage;
        healthBase.OnKill += OnKill;
    }

    private void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    void Update()
    {

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (_alive)
        {
            if (characterController.isGrounded)
            {
                vSpeed = 0;
                if (Input.GetKeyDown(jumpKeyCode))
                {
                    vSpeed = jumpSpeed;
                }
            }

            vSpeed -= gravity * Time.deltaTime;
            speedVector.y = vSpeed;

            var isWalking = inputAxisVertical != 0;
            if (isWalking)
            {
                if (Input.GetKey(runKeyCode))
                {
                    speedVector *= speedRun;
                    animator.speed = speedRun;
                }
                else
                {
                    animator.speed = 1;
                }
            }

            if (Input.GetKey(jetKeyCode))
            {
                vSpeed += jetSpeed;
                jetParticles.Play();
                timeJet = 100;
            }

            if (Input.GetKeyDown(gun1KeyCode))
            {
                playerAbilityShoot.TradeGun(gunInvetory[0]);
                Debug.Log("apertou 1");

            }

            if (Input.GetKeyDown(gun2KeyCode))
            {
                Debug.Log("apertou 2");
                playerAbilityShoot.TradeGun(gunInvetory[1]);
            }

            timeJet--;

            if (timeJet <= 0)
            {
                jetParticles.Stop();
            }

            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

            characterController.Move(speedVector * Time.deltaTime);

            animator.SetBool("Run", inputAxisVertical != 0);

        }

    }

    #region life

    private void OnKill(HealthBase h)
    {
        if (_alive)
        {
            _alive = false;
            animator.SetTrigger("Death");
            colliders.ForEach(i => i.enabled = false);

            Invoke(nameof(Revive), 3f);
        }
    }

    private void Revive()
    {
        _alive = true;
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        Respawn();
        Invoke(nameof(TurnOnColliders), .1f);
    }

    private void TurnOnColliders()
    {
        colliders.ForEach(i => i.enabled = true);
    }

    public void Damage(HealthBase h)
    {
        FlashColors.ForEach(i => i.Flash());
    }

    public void Damage(float damage, Vector3 dir)
    {
        //Damage(damage);
    }
    #endregion

    public void Respawn()
    {
        if (CheckpointManager.Instance.HasCheckpoint())
        {
            transform.position = CheckpointManager.Instance.GetPositionFromLastCheckpoint();
        }
    }
}

/*
 *      


 * 
 */