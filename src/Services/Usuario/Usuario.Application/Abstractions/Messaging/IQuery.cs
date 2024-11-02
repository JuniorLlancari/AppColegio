using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Usuario.Domain.Abstractions;

namespace Usuario.Application.Abstractions.Messaging;


public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
