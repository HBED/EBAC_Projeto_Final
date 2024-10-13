using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Cloth
{
    public enum ClothType
    {
        SPEED,
        STRONG,
        LIGHT
    }

    public class ClothManager : Singleton<ClothManager>
    {
        public List<ClothSetup> clothSetups;

        public ClothSetup currentCloth;

        public ClothSetup GetSetupByType(ClothType clothType)
        {
            currentCloth = clothSetups.Find(i => i.clothType == clothType);

            return currentCloth;
        }

        public ClothSetup GetSetupById(int idCloth)
        {
            currentCloth = clothSetups.Find(i => i.id == idCloth);

            return currentCloth;
        }
    }

    [System.Serializable]
    public class ClothSetup
    {
        public int id;
        public ClothType clothType;
        public Texture2D texture;
    }
}

