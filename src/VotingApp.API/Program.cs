using FluentValidation;
using VotingApp.API.Candidate;
using VotingApp.API.Shared.Extensions;
using VotingApp.API.Vote;
using VotingApp.API.Voter;
using VotingApp.Domain.Candidate.Repositories;
using VotingApp.Domain.Vote.Repositories;
using VotingApp.Domain.Voter.Repositories;
using VotingApp.Infrastructure.Candidate.Repositories;
using VotingApp.Infrastructure.Shared.Options;
using VotingApp.Infrastructure.Vote.Repositories;
using VotingApp.Infrastructure.Voter.Repositories;

var builder = WebApplication.CreateBuilder(args);
var mongoOptions = new MongoOptions();

builder.Configuration.GetSection(nameof(MongoOptions)).Bind(mongoOptions);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.Configure<MongoOptions>(builder.Configuration.GetSection(nameof(MongoOptions)));
builder.Services.AddMongo(mongoOptions);
builder.Services.AddScoped<IVoteRepository, VoteRepository>();
builder.Services.AddScoped<IVoterRepository, VoterRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddCors();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:3000"));

app.MapGroup("/candidate")
    .MapCandidateApi()
    .WithTags("Candidate");

app.MapGroup("/voter")
    .MapVoterApi()
    .WithTags("Voter");

app.MapGroup("/vote")
    .MapVoteApi()
    .WithTags("Vote");

app.Run();