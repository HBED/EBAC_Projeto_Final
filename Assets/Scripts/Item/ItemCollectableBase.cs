using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

namespace Itens
{
    public class ItemCollectableBase : MonoBehaviour
    {
        public ItemType itemType;

        public string compareTag = "Player";
        public ParticleSystem particleSystem;
        public float timeToHide = 3;
        public GameObject graphicItem;
        private bool noCollected = true;

        public Collider collider;

        [Header("Sounds")]
        public AudioSource audioSource;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag) && noCollected)
            {
                Collect();
            }
        }

        protected virtual void Collect()
        {
            if (collider != null) collider.enabled = false;
            if (graphicItem != null) graphicItem.SetActive(false);
            OnCollect();
            Invoke("HideObject", timeToHide);
            noCollected = false;
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect()
        {
            if (particleSystem != null) particleSystem.Play();
            if (audioSource != null) audioSource.Play();
            ItemManager.Instance.AddByType(itemType);
        }

    }



}


