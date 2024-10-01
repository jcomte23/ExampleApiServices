using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExampleApiServices.Config;
public class CustomOperationOrderingFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // Creamos un nuevo objeto OpenApiPaths para mantener las rutas con operaciones ordenadas
        var newPaths = new OpenApiPaths();

        // Iteramos por cada ruta en el documento Swagger
        foreach (var path in swaggerDoc.Paths)
        {
            // Obtenemos las operaciones (GET, POST, PUT, DELETE) y las ordenamos
            var orderedOperations = path.Value.Operations
                .OrderBy(op =>
                {
                    switch (op.Key)
                    {
                        case OperationType.Get:
                            return 0;
                        case OperationType.Post:
                            return 1;
                        case OperationType.Put:
                            return 2;
                        case OperationType.Delete:
                            return 3;
                        default:
                            return 4; // Otros métodos como PATCH, etc.
                    }
                })
                .ToDictionary(op => op.Key, op => op.Value);

            // Creamos un nuevo OpenApiPathItem con las operaciones ordenadas
            var orderedPathItem = new OpenApiPathItem();
            foreach (var operation in orderedOperations)
            {
                orderedPathItem.Operations.Add(operation.Key, operation.Value);
            }

            // Añadimos la ruta con las operaciones ordenadas al nuevo objeto de rutas
            newPaths.Add(path.Key, orderedPathItem);
        }

        // Asignamos las rutas con operaciones ordenadas al documento Swagger
        swaggerDoc.Paths = newPaths;
    }
}

