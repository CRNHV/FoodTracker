using FoodTracker.Data.Domain.Application.Authentication;
using System;

namespace FoodTracker.Application.Authentication;

internal sealed class User : IUser
{
    public int Id { get; init; }
    public string Username { get; init; }
    public DateTime LastLogin { get; init; }
}