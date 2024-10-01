﻿using NeonBlack.Entities.Player;
using NeonBlack.Enums;
using NeonBlack.Utilities;
using UnityEngine;

namespace NeonBlack.Projectiles
{
    public class SimpleEnemyProjectile : Projectile
    {
        #region Serialized Fields

        [SerializeField]
        private float speed = 10f;

        #endregion

        #region Event Functions

        private void Update()
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            var layer = (Layer)other.gameObject.layer;

            switch (layer)
            {
                case Layer.Terrain:
                    ObjectPoolManager.Despawn(this);
                    break;
                case Layer.Player when other.TryGetComponent(out PlayerController player):
                    player.Kill();
                    break;
            }
        }

        #endregion
    }
}
