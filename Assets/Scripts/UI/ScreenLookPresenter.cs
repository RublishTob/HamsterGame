using UniRx;

public class ScreenLookPresenter
{
    private ScreenLook _view;
    private VideoSystem _model;
    private Logger _logger;
    public ScreenLookPresenter(ScreenLook view, VideoSystem model, Logger logger)
    {
        _view = view;
        _model = model;
        _logger = logger;
        _model.Resolution.Subscribe(value => {
            ChangeScreenSize(value);
        });
    }
    public void ChangeScreenSize(int resolution)
    {
        if(resolution == 0)
        {
            _view.SetScreenResolution(1920, 1080);
            _logger.Log("1920");
        }
        if(resolution == 1)
        {
            _view.SetScreenResolution(1024, 768);
        }
        if (resolution == 2)
        {
            _view.SetScreenResolution(4, 3);
        }
    }
}
