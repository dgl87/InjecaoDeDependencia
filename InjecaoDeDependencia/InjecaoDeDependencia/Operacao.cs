using System;

namespace InjecaoDeDependencia
{
    public class Operacao : IOperacao, IOperacaoTransient, IOperacaoSccoped, IOperacaoSingleton
    {
        public Guid Id { get; set; }
        public Operacao()
        {
            Id = Guid.NewGuid();
        }
    }

    
    public interface IOperacao
    {
        Guid Id { get; set; }
    }
    public interface IOperacaoTransient : IOperacao
    {

    }
    public interface IOperacaoSccoped : IOperacao
    {

    }
    public interface IOperacaoSingleton : IOperacao
    {

    }
}
