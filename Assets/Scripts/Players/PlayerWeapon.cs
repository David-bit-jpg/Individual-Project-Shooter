using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Weapon InitialWeapon;
    [SerializeField] private Transform WeaponPos;
    
    private Weapon CurrentWeapon;
    private PlayerMovement PlayerMovement;
    private PlayerActions action;
    private bool isShooting = false;
    public Joystick joystick;
    private bool hasStartedShooting = false;
    public void ChangeWeapon(Weapon newWeapon)
    {
        if (CurrentWeapon != null)
        {
            Vector3 playerPosition = transform.position;

            //Weapon droppedWeapon = Instantiate(CurrentWeapon, playerPosition, Quaternion.identity);
            //droppedWeapon.transform.parent = null; 
            Destroy(CurrentWeapon.gameObject);
        }

        CurrentWeapon = newWeapon;
        CreateWeapon(CurrentWeapon);
    }


    private void Awake()
    {
        action = new PlayerActions();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        action.Weapon.Shoot.started += ctx => StartShooting();
        action.Weapon.Shoot.canceled += ctx => StopShooting();
        CreateWeapon(InitialWeapon);
    }

    private void Update()
    {
        Vector3 joystickDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0f);

        if (PlayerMovement.moveDirection != Vector2.zero)
        {
            RotateWeapon(PlayerMovement.moveDirection);

            if (!hasStartedShooting)
            {
                StartShooting();
                hasStartedShooting = true;
            }
        }
        else if (joystickDirection != Vector3.zero)
        {
            RotateWeapon(joystickDirection);

            if (!hasStartedShooting)
            {
                StartShooting();
                hasStartedShooting = true;
            }
        }
        else
        {
            StopShooting();
            hasStartedShooting = false;
        }
    }

    private void CreateWeapon(Weapon weapon)
    {
        CurrentWeapon = Instantiate(weapon, WeaponPos.position, Quaternion.identity, WeaponPos);
    }

    private void StartShooting()
    {
        isShooting = true;
        StartCoroutine(ShootInterval());
    }

    private void StopShooting()
    {
        isShooting = false;
    }

    private IEnumerator ShootInterval()
    {
        while (isShooting)
        {
            ShootWeapon();
            yield return new WaitForSeconds(CurrentWeapon.ItemWeapon.ShotSpeed);
        }
    }

    private void ShootWeapon()
    {
        if (CurrentWeapon == null)
            return;
        CurrentWeapon.UseWeapon();
        Debug.Log("Shooting!");
    }

    private void RotateWeapon(Vector3 Direction)
    {
        float angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        if (Direction.x > 0f)
        {
            WeaponPos.localScale = Vector3.one;
            CurrentWeapon.transform.localScale = Vector3.one;
        }
        else
        {
            WeaponPos.localScale = new Vector3(-1, -1, 1);
            CurrentWeapon.transform.localScale = new Vector3(-1, 1, 1);
        }
        CurrentWeapon.transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
