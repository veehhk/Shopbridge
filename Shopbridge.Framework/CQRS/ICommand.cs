using System;

namespace Shopbridge.Framework.CQRS
{
    public interface ICommand<T, Type>
    {
        public Type Id { get; }
        public T Arguments { get; set; }
    }

    public class Command<T, Type> : ICommand<T, Type>
    {
        public Type Id { get; set; }
        public T Arguments { get; set; }
    }
}