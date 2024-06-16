namespace MVC
{
    public class ControllerBase<TM, TV>
    {
        protected readonly TM Model;
        protected readonly TV View;
        
        protected ControllerBase(TM model, TV view)
        {
            Model = model;
            View = view;
        }
    }
}