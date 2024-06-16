using UnityEngine;

namespace MVC
{
    public class ViewBase<TM, TC> : MonoBehaviour
    {
        [SerializeField] protected TM model;
        protected TC Controller;

        protected void InitializeController(TC controller)
        {
            Controller = controller;
        }
    }
}