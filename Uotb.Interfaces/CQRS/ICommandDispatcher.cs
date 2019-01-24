﻿using System.Threading.Tasks;

namespace Uotb.Interfaces.CQRS
{
    public interface ICommandDispatcher
    {
        Task<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand;

        Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
