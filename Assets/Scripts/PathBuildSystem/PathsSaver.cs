using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PathBuildSystem
{
    public class PathsSaver
    {
        private static readonly string FilePath = Path.Combine(Application.persistentDataPath, "pathsSave.paths");
        
        public void Save()
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
            }
        }
    }
}