using System;
using System.Collections.Generic;
using DevourDev.Unity.Utils;
using Game.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Game.Core
{
    //todo: decompose checkpoints (and much more)
    public class GameManager : MonoBehaviour
    {
        //debug
        [SerializeField] private GameObject _resultPanel;
        [SerializeField] private TextMeshProUGUI _resultText;
        //==

        [SerializeField] private SceneBounderBase _fullBounder;
        [SerializeField] private SceneBounderBase _playerBounder;
        [SerializeField] private SceneBounderBase _enemiesBounder;

        [SerializeField] private GameObject _playerShip;
        [SerializeField] private float _shipSpeed;




        [Space]
        [SerializeField] private AnimationCurve _distanceMoneyOverDistance;

        [Space]
        [Tooltip("Радиус безопасной зоны вокруг чекпоинта. В безопасной" +
            " зоне не спавнятся опасные сущности")]
        [SerializeField] private float _checkPointSafeDistance = 1000f;
        [SerializeField] private CheckPointCreator[] _specialCheckPoints;

        [Header("Auto Check Points")]
        [SerializeField] private float _crossCheckPointsDistance = 10_000f;
        [SerializeField] private float _checkPointsBounty = 3_000f;
        [SerializeField] private float _bountyFlatStep = 350f;

        private HealthComponent _playerShipHealth;
        private ShieldDamageProcessor _playerShipShield;

        private double _distancePassed;
        private long _moneyEarned;
        private float _moneyReminder;

        private int _lastSpecialCheckPointIndex = -1;
        private float _nextCheckPointDist;
        private bool _inSafeZone;

        private readonly List<CheckPointData> _lastCheckPoints = new();



        public double DistancePassed => _distancePassed;
        public long MoneyEarned => _moneyEarned;

        public bool InSafeZone => _inSafeZone;


        /// <summary>
        /// value
        /// </summary>
        public event System.Action<double> OnPassedDistanceChanged;
        /// <summary>
        /// value, delta
        /// </summary>
        public event System.Action<long, long> OnEarnedMoneyChanged;


        private void Awake()
        {
            RuntimeAccessors.MainSceneBounder = _fullBounder;
            RuntimeAccessors.PlayerBounder = _playerBounder;
            RuntimeAccessors.EnemiesBounder = _enemiesBounder;

            _playerShipHealth = _playerShip.GetComponent<HealthComponent>();
            _playerShipShield = _playerShip.GetComponent<ShieldDamageProcessor>();

            _playerShipHealth.OnDeath += HandlePlayerDied;
        }

        private void Update()
        {
            ProgressDistance();
            ProcessDistance();
        }

        private void ProcessDistance()
        {
            CheckCheckPoints();
        }

        private void CheckCheckPoints()
        {
            var scpDist = CheckSpecialCheckPoints();
            var cpDist = CheckBaseCheckPoints();

            float min = Mathf.Min(Mathf.Abs(scpDist), Mathf.Abs(cpDist));

            float closestNext = scpDist;

            if (scpDist < 0)
                closestNext = cpDist;

            _nextCheckPointDist = closestNext;

            SetInSafeZoneState(min < _checkPointSafeDistance);
        }

        private void SetInSafeZoneState(bool inSafeZone)
        {
            _inSafeZone = inSafeZone;
        }

        private float CheckBaseCheckPoints()
        {
            //todo: implement

            return float.PositiveInfinity;
        }

        private float CheckSpecialCheckPoints()
        {
            int nextScpIndex = _lastSpecialCheckPointIndex + 1;

            if (nextScpIndex == _specialCheckPoints.Length)
                return float.PositiveInfinity;

            var scp = _specialCheckPoints[_lastSpecialCheckPointIndex + 1];
            float dist = scp.Distance - (float)_distancePassed;

            if (dist < 0)
            {
                ++_lastSpecialCheckPointIndex;
                ProcessCheckPoint(new CheckPointData(dist, scp.Reward,
                    _playerShipHealth.StatValue, _playerShipShield.StatValue));
            }

            return dist;
        }

        private void ProcessCheckPoint(CheckPointData checkPointData)
        {
            Debug.Log("CHECKPOINT REACHED!");
            _lastCheckPoints.Add(checkPointData);
            //TODO: implement reward
        }

        private void ProgressDistance()
        {
            float delta = _shipSpeed * Time.deltaTime;
            _distancePassed += delta;
            OnPassedDistanceChanged?.Invoke(_distancePassed);

            MoneyFromDistance(delta);
        }

        private void MoneyFromDistance(float delta)
        {
            float price = _distanceMoneyOverDistance.Evaluate((float)_distancePassed);
            float earning = price * delta + _moneyReminder;
            long longEarning = (long)earning;
            _moneyReminder = earning - longEarning;
            _moneyEarned += longEarning;
            OnEarnedMoneyChanged?.Invoke(_moneyEarned, longEarning);
        }

        public void ContinueFromCheckPoint(CheckPointData checkPointData)
        {
            _distancePassed = checkPointData.Distance;
            _moneyEarned = checkPointData.Money;

            ((IStat)_playerShipHealth).SetStatValue(checkPointData.ShipHealth);
            ((IStat)_playerShipShield.GetComponent<ShieldDamageProcessor>()).SetStatValue(checkPointData.ShieldDurability);
        }

        private void HandlePlayerDied(HealthComponent health)
        {
            EndGame(EndGameReason.PlayerDied);
        }

        private void EndGame(EndGameReason reason)
        {
            enabled = false;
            _resultText.text = $"Game over. Result: {reason}";
            _resultPanel.SetActive(true);
            this.ExecuteDelayed(ReloadScene, 5f);
        }

        private static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}