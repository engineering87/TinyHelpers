﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace TinyHelpers.AspNetCore.Swagger;

public static class OpenApiSchemaHelper
{
    public static OpenApiSchema CreateStringSchema(string? defaultValue = null)
    {
        var schema = new OpenApiSchema
        {
            Type = "string",
            Default = defaultValue is not null ? new OpenApiString(defaultValue.ToString()) : null
        };

        return schema;
    }

    public static OpenApiSchema CreateSchema<TValue>(string type, string? format = null)
    {
        var schema = new OpenApiSchema
        {
            Type = type,
            Format = format
        };

        return schema;
    }

    public static OpenApiSchema CreateSchema<TValue>(string type, string? format, TValue? defaultValue = null) where TValue : struct
    {
        var schema = new OpenApiSchema
        {
            Type = type,
            Format = format,
            Default = defaultValue is not null ? new OpenApiString(defaultValue.ToString()) : null
        };

        return schema;
    }

    public static OpenApiSchema CreateSchema(IEnumerable<string> values, string? defaultValue = null)
    {
        var schema = new OpenApiSchema
        {
            Type = "string",
            Enum = values.Select(v => new OpenApiString(v)).Cast<IOpenApiAny>().ToList(),
            Default = defaultValue is not null ? new OpenApiString(defaultValue.ToString()) : null
        };

        return schema;
    }

    public static OpenApiSchema CreateSchema<TEnum>(TEnum? defaultValue = null) where TEnum : struct, Enum
    {
        var schema = new OpenApiSchema
        {
            Type = "string",
            Enum = Enum.GetValues<TEnum>().Select(e => new OpenApiString(e.ToString())).Cast<IOpenApiAny>().ToList(),
            Default = defaultValue.HasValue ? new OpenApiString(defaultValue.ToString()) : null
        };

        return schema;
    }
}