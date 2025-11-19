using FuturoDoTrabalho.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/api/simulate", (SimulationRequest request) =>
{
    PapelTrabalho workRole = request.WorkModel switch
    {
        "Remoto" => new RemoteWorker(),
        "Híbrido" => new HybridWorker(),
        "Presencial" => new OnsiteWorker(),
        _ => new HybridWorker()
    };

    var simulator = new FutureWorkSimulator(workRole);

    var index = simulator.CalculateFutureIndex(
        request.Automation,
        request.Wellbeing,
        request.Inclusion,
        request.Sustainability);

    var classification = simulator.ClassifyIndex(index);

    var recommendations = simulator.GenerateRecommendations(
        request.Automation,
        request.Wellbeing,
        request.Inclusion,
        request.Sustainability);

    return Results.Ok(new SimulationResponse(index, classification, recommendations));
});

app.Run();

public sealed record SimulationRequest(
    string WorkModel,
    double Automation,
    double Wellbeing,
    double Inclusion,
    double Sustainability);

public sealed record SimulationResponse(
    double Index,
    string Classification,
    string Recommendations);

