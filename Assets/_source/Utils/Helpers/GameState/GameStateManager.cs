﻿using UnityEngine;

namespace Game.Helpers
{
    public class GameStateManager : MonoBehaviour
    {
        public void SetPauseState(bool paused)
        {
            EasyGameStateProvider.IsPaused = paused;
        }

        public void SetPlayerAliveState(bool alive)
        {
            EasyGameStateProvider.IsPlayerAlive = alive;
        }


        private void Start()
        {
            EasyGameStateProvider.IsPaused = false;
            EasyGameStateProvider.IsPlayerAlive = true;
        }
    }
}
