using System.Collections.Generic;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Phone.Screens
{
    public class MainScreen : ScreenBase
    {
        [field: SerializeField] public Button StartWorkButton { get; private set; }
        [field: SerializeField] public Button ViewOrderInfoButton { get; private set; }
        
        /// <summary>
        /// При нажатии на кнопку начала работы
        /// </summary>
        public void OnStartWorkClicked()
        {
            Phone.ShowScreen<SearchOrderScreen>();
        }

        /// <summary>
        /// При нажатии на кнопку просмотра информации об активном заказе
        /// </summary>
        public void OnViewOrderInfoClicked()
        {
            Phone.ShowScreen<OrderInfoScreen>();
        }
    }
}