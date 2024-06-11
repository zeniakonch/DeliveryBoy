using ServiceLocatorSystem;

namespace Phone.Screens
{
    public class MainScreen : ScreenBase
    {
        /// <summary>
        /// При нажатии на кнопку начала работы
        /// </summary>
        public void OnStartWorkClicked()
        {
            Phone.ShowScreen<SearchOrderScreen>();
        }
    }
}