using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "NewInputConfig", menuName = "Game/Configs/InputConfig")]
    public class InputConfig : ScriptableObject
    {
        public KeyCode phoneKey;
        public KeyCode interactKey;
    }
}