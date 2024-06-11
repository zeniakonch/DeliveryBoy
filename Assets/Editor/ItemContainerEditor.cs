// using Scripts.InventoryScripts;
// using UnityEditor;
// using UnityEngine;
//
// namespace Editor
// {
//     [CustomEditor(typeof(ItemContainer))]
//     public class ItemContainerEditor : UnityEditor.Editor
//     {
//         public override void OnInspectorGUI()
//         {
//             ItemContainer container = target as ItemContainer;
//             if (GUILayout.Button("Clear container"))
//             {
//                 for (int i = 0; i < container!.Slots.Count; i++) // ахтунг возможно говно
//                 {
//                     container.Slots[i].Clear();
//                 }
//             }
//             DrawDefaultInspector();
//         }
//     }
// }
