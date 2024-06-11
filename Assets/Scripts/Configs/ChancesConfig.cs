using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "NewChancesConfig", menuName = "Game/Configs/ChancesConfig")]
    public class ChancesConfig : ScriptableObject
    {
        [Range(0, 1)]
        public float getOrderChance;
    }
}
