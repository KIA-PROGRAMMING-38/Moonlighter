﻿namespace Enums
{
    public enum FacingDirection
    {
        Up,
        Down,
        Left,
        Right,
        Count
    }

    public enum PlayerState
    {
        Idle,
        Move,
        Roll,
        Count
    }

    public enum CharacterStatId
    {
        Player = 1,
        Count
    }

    public enum EffectId
    {
        MoveEffect = 1,
        RollEffect,
        Count
    }
}