using System;
using System.Windows.Input;

namespace FamilyAlbum.App.Commands;

public class LambdaCommand : ICommand
{
    private readonly Predicate<object?> _canExecute;
    private readonly Action<object?> _execute;

    public LambdaCommand(Predicate<object?> canExecute, Action<object?> execute)
    {
        _canExecute = canExecute;
        _execute = execute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}