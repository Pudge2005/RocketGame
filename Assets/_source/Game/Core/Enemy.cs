using Game.Controller;
using Game.SpaceShip;
using UnityEngine;

namespace Game.Core
{
    //todo: implement turrel initing/using values from EnemyStats/through Enemy
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private Turrel _turrel;
        [SerializeField] private Controller2D _controller;

        private EnemyStats _stats;


        public void InitEnemy(EnemyStats stats)
        {
            _stats = stats;
        }

    }
}