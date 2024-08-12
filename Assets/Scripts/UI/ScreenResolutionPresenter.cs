using UniRx;

public class ScreenResolutionPresenter
{
    private ScreenResolution _view;
    private VideoSystem _model;
    private Logger _logger;
    public ScreenResolutionPresenter(ScreenResolution view, VideoSystem model, Logger logger)
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
            _view.SetScreenResolution(1024, 768);
        }
        if(resolution == 1)
        {
            _view.SetScreenResolution(1920, 1080);
        }
        if (resolution == 2)
        {
            _view.SetScreenResolution(3840, 2160);
        }
    }
}
