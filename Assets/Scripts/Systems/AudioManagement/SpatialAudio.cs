﻿using UnityEngine;

namespace Systems.AudioManagement
{
    public class SpatialAudio : PoolObject
    {
        #region Serialized Fields

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private Vector2 pitchRandomization = new(0.9f, 1.1f);

        #endregion

        #region Event Functions

        private void FixedUpdate()
        {
            if (audioSource.isPlaying)
            {
                return;
            }

            ObjectPoolManager.Despawn(this);
        }

        #endregion

        internal void Play(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.pitch = Random.Range(pitchRandomization.x, pitchRandomization.y);
            audioSource.Play();
        }

        public void Stop()
        {
            if (!this)
            {
                return;
            }

            audioSource.Stop();
            ObjectPoolManager.Despawn(this);
        }
    }
}
