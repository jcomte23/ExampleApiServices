using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;

[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesController(IVehicleRepository vehicleRepository) : ControllerBase
{
    protected readonly IVehicleRepository _vehicleRepository = vehicleRepository;
}
