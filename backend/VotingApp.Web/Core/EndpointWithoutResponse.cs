using FastEndpoints;

namespace VotingApp.Web.Core;

public abstract class EndpointWithoutResponse<TRequest, TMapper>
    : Endpoint<TRequest, object, TMapper> 
    where TRequest : notnull 
    where TMapper : IMapper {  }