internal interface IPanel
{
    void Show(string nameOfPanel);
    void Hide();
    public string Id { get; }
}