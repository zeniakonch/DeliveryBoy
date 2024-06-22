using UnityEngine;

namespace SaveLoadSystem
{
    [CreateAssetMenu(fileName = "NewSaveFilesPaths", menuName = "Game/Configs/SaveFilesPaths")]
    public class SaveFilesPathsConfig : ScriptableObject
    {
        public string pathBakeFile;
    }
}