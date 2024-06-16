using MVC;

namespace OrdersSystem.GetOrderWindow
{
    public class GetOrderWindowController : ControllerBase<GetOrderWindowModel, GetOrderWindowView>
    {
        public GetOrderWindowController(GetOrderWindowModel model, GetOrderWindowView view) : base(model, view)
        {
        }
    }
}