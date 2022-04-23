using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Core core;
    Collider2D _collider;
    [SerializeField] private LayerMask groundLayerMask;

    public PlayerStateMachine StateMachine; 

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }

    [SerializeField]
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }

    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        core = GetComponentInChildren<Core>();
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData);
        MoveState = new PlayerMoveState(this, StateMachine, playerData);
        JumpState = new PlayerJumpState(this, StateMachine, playerData);
        InAirState = new PlayerInAirState(this, StateMachine, playerData);
        

    }
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
         
        StateMachine.Initialize(IdleState);

    }

    private void Update()
    {
        core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

   
}
