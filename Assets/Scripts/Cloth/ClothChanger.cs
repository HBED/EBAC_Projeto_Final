using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cloth;

namespace Cloth
{
    public class ClothChanger : MonoBehaviour
    {
        public SkinnedMeshRenderer mesh;

        public Texture2D texture;
        public string shaderIdName = "_EmissionMap";

        private Texture2D _defaultTexture;

        private void Awake()
        {
            _defaultTexture = (Texture2D) mesh.sharedMaterials[0].GetTexture(shaderIdName);

        }

        private void Start()
        {
            int idSaveCloth = SaveManager.Instance.Setup.idCloth;

            if (idSaveCloth != 0)
            {
                ClothSetup saveSetup = ClothManager.Instance.GetSetupById(idSaveCloth);
                ChangeTexture(saveSetup);
            }
        }

        [NaughtyAttributes.Button]
        private void ChangeTexture()
        {
            mesh.materials[0].SetTexture(shaderIdName, texture);
        }

        public void ChangeTexture(ClothSetup setup)
        {
            mesh.materials[0].SetTexture(shaderIdName, setup.texture);
        }

        public void ResetTexture()
        {
            mesh.sharedMaterials[0].SetTexture(shaderIdName, _defaultTexture);
        }
    }
}

