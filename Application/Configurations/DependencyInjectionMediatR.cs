﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Employee.Commands.Create;

namespace Application.Configurations;

public static class DependencyInjectionMediatR
{
    public static IServiceCollection AddApplicationMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateEmployeeCommand).Assembly);

        return services;
    }
}
