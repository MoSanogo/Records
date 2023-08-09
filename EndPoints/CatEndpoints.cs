using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Records.Data.Dtos;
using Records.Data.Entities;
using Records.Events;
using Records.Mediatr.Commands;
using Records.Mediatr.Queries;

namespace Records.EndPoints;

public static class CatEndpoints
{
    public static void MapCatEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/Cats/").WithTags(nameof(Cat));
        

        group.MapGet("/", async Task<Results<Ok<IEnumerable<CatDto>>,ProblemHttpResult>> (IMediator mediatr) =>
        {
            try
            {
                var result = await mediatr.Send(new GetCatsQuery());

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }
        })
        .WithName("GetAllCats")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<CatDto>, NotFound, ProblemHttpResult >> (string id, IMediator mediatr, IMapper mapper) =>
        {
            try
            {
                CatDto candidate = await mediatr.Send(new GetCatQueryById(id));
                if (candidate == null) { return TypedResults.NotFound(); }
                return TypedResults.Ok(candidate);
            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }
        })
        .WithName("GetCatById")
        .WithOpenApi();

        group.MapPatch("/{id}", async Task<Results<Ok<bool>, ProblemHttpResult>> (string id, CatUpdateDto input, IMediator mediatr, CancellationToken cancellationToken) =>
        {
            try
            {
            
                var result= await mediatr.Send(new UpdateCommand(id, input),cancellationToken);
                if(result) await mediatr.Publish(new CatRecordUpdateEvent(id ), cancellationToken);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }
        })
        .WithName("UpdateCat")
        .WithOpenApi();

        group.MapPost("/", async Task<Results<Ok<CatDto>,ProblemHttpResult >> (CatAddDto model, IMapper mapper, IMediator mediatr, CancellationToken cancellationToken) =>
        {
            try
            {
               
                var result = await mediatr.Send(new AddCatCommand(model), cancellationToken);
                await mediatr.Publish(new CatRecordAddEvent(result.Id.ToString()), cancellationToken);
                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        })
        .WithName("CreateCat")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok<bool>, ProblemHttpResult>> (string id,IMediator mediatr, CancellationToken cancellationToken) =>
        {
            try
            {
                var result = await mediatr.Send(new DeleteCommand(id), cancellationToken);
                return TypedResults.Ok(result);

            }

            catch (Exception ex)
            {

                return TypedResults.Problem(ex.Message);
            }
            
        })
        .WithName("DeleteCat")
        .WithOpenApi();
    }
}
