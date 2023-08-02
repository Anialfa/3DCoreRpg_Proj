using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PlayerStateEnum
{ 
idel,
run,
attack,
gethit,
die,
}
public class PlayerCtrl : MonoBehaviour
{
    Animator _SelfAnim;
    PlayerStateEnum _currentState;
    NavMeshAgent _selfAgent;
    Vector3 _desPos;
    float _stopDistence=0.3f;
    private void Start()
    {
        _SelfAnim = GetComponent<Animator>();
        _selfAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //StateMachine();
        MouseDectect();
        MouseInput();
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwitchState(PlayerStateEnum.run); 
        }
    }

    private void MouseDectect()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitinfo;
        if (Physics.Raycast(mouseRay,out hitinfo))
        {
            _desPos = hitinfo.point;
            
        }
    }

    private void StateMachine()
    {
        switch (_currentState)
        {
            case PlayerStateEnum.idel:
                Idleing();
                break;
            case PlayerStateEnum.run:
                Runnuing();
                break;
            case PlayerStateEnum.attack:
                Attacking();
                break;
            case PlayerStateEnum.gethit:
                GettingHit();
                break;
            case PlayerStateEnum.die:
                Die();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 切换到目标状态
    /// </summary>
    /// <param name="targetState"></param>
    void SwitchState(PlayerStateEnum targetState)
    {
        //在还没有转过去的时候，先做一些事情
        switch (_currentState)
        {
            case PlayerStateEnum.idel:               
                break;
            case PlayerStateEnum.run:
                break;
            case PlayerStateEnum.attack:
                break;
            case PlayerStateEnum.gethit:
                break;
            case PlayerStateEnum.die:
                break;
            default:
                break;
        }

        //转换时，要做什么事
        switch (targetState)
        {
            case PlayerStateEnum.idel:
                Idle();
                break;
            case PlayerStateEnum.run:
                Run();
                break;
            case PlayerStateEnum.attack:
                Attack();
                break;
            case PlayerStateEnum.gethit:
                GetHit();
                break;
            case PlayerStateEnum.die:
                Dead();
                break;
            default:
                break;
        }

        _currentState = targetState;

        //转换以后，要做什么事
        switch (_currentState)
        {
            case PlayerStateEnum.idel:
                break;
            case PlayerStateEnum.run:
                break;
            case PlayerStateEnum.attack:
                break;
            case PlayerStateEnum.gethit:
                break;
            case PlayerStateEnum.die:
                break;
            default:
                break;
        }

    }

    private void Dead()
    {
       
    }

    private void GetHit()
    {
      
    }

    private void Attack()
    {
       
    }

    private void Run()
    {
        _selfAgent.SetDestination(_desPos);
        _SelfAnim.SetBool("Run", true);
    }

    private void Idle()
    {
        _SelfAnim.SetBool("Run", false);
    }

    private void Die()
    {
      
    }

    private void GettingHit()
    {
        
    }

    private void Attacking()
    {
    }

    private void Runnuing()
    {
        if (_selfAgent.remainingDistance<_stopDistence)
        {
            SwitchState(PlayerStateEnum.idel);
        }
    }

    private void Idleing()
    {
        
    }
}
