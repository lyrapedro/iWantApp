﻿using iWantApp.Infra.Data;
using Microsoft.AspNetCore.Authorization;

namespace iWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {
        if (page == null || page.Value < 0)
            return Results.BadRequest("Page is required");

        if (rows == null || rows.Value < 0)
            rows = 10;

        return Results.Ok(query.Execute(page.Value, rows.Value));
    }
}
