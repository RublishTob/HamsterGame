internal interface IPanel
{
    public void Show(string nameOfPanel);
    public void Hide();
    public void DisposeResourse();
    public string Id { get; }
}