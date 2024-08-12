using System;
public class DisposeManager
{
    public event Action DisposeRes;

    public void DisposeResourse()
    {
        DisposeRes?.Invoke();
    }
}
