using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{

    [Header("Movement")]
    public float moveSpeed = 10f;

    [Header("Jumping")]
    public float jumpForce = 20f;
    public int maxJumps = 1;
    public float coyoteTime = 1.0f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Shield Values")]
    public float shieldJumpMultiplier = 1.3f;
    public float shieldThrowForce = 10.0f;
}
