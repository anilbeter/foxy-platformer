using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls myControls;

    public float valueX;
    public bool jumpInput;

    public bool tryAttack;

    private void Awake()
    {
        myControls = new Controls();
    }

    private void OnEnable()
    {
        myControls.Player.Move.performed += StartMove;
        myControls.Player.Move.canceled += StopMove;

        myControls.Player.Jump.performed += JumpStart;
        myControls.Player.Jump.canceled -= JumpStop;

        myControls.Player.Attack.performed += TryToAttack;
        myControls.Player.Attack.canceled += StopTryToAttack;

        myControls.Player.Enable();
    }

    private void OnDisable()
    {
        myControls.Player.Move.performed -= StartMove;
        myControls.Player.Move.canceled -= StopMove;

        myControls.Player.Jump.performed -= JumpStart;
        myControls.Player.Jump.canceled -= JumpStop;

        myControls.Player.Attack.performed -= TryToAttack;
        myControls.Player.Attack.canceled -= StopTryToAttack;

        myControls.Player.Disable();
    }

    public void DisableControls()
    {
        myControls.Player.Move.performed -= StartMove;
        myControls.Player.Move.canceled -= StopMove;

        myControls.Player.Jump.performed -= JumpStart;
        myControls.Player.Jump.canceled -= JumpStop;

        myControls.Player.Disable();
        // clear input
        valueX = 0;
    }

    private void StartMove(InputAction.CallbackContext ctx)
    {
        // Gamepad sticki kullandığım zaman değerler 0.1, 0,2, ..., 1 e kadar gidiyor (ya da -1e kadar) ve bunun sonucu karakter harekete yavaş başlayıp hızlanıyor. Bunu istemediğim için Mathf.RoundToInt kullandım. Input olarak sadece -1, 0 ve 1 istiyorum, hareket hızı sabit olmalı
        // 0.2 -> 0'a yuvarlanacak
        // 0.5 - 0.9 -> 1
        valueX = Mathf.RoundToInt(ctx.ReadValue<float>());
    }

    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0f;
    }

    private void JumpStart(InputAction.CallbackContext ctx)
    {
        jumpInput = true;
    }

    private void JumpStop(InputAction.CallbackContext ctx)
    {
        jumpInput = false;
    }

    private void TryToAttack(InputAction.CallbackContext ctx)
    {
        tryAttack = true;
    }

    private void StopTryToAttack(InputAction.CallbackContext ctx)
    {
        tryAttack = false;
    }
}
