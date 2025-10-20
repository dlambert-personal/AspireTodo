//using MediatR;

namespace TodoStates.CrossCutting.CQRS;

public interface IQuery<out TResponse>;
//public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull;
