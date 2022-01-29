using iWantApp.Domain.Products;
using iWantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace iWantApp.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null) return Results.NotFound("Category does not exist");

        context.Remove(category);

        context.SaveChanges();

        return Results.Ok();
    }
}
