
using Zenject;

public class UIControllerFactory
{
    private DiContainer _container;
    public UIControllerFactory(DiContainer container)
    {
        _container = container;
    }
    public ButtonController CreateButtonContoller()
    {
        ButtonController buttonController = new ButtonController();
        _container.Inject(buttonController);
        return buttonController;
    }

}
