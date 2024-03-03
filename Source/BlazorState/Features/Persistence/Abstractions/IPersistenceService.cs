﻿#nullable enable
namespace TimeWarp.Features.Persistence.Abstractions;

public interface IPersistenceService
{
    Task<object?> LoadState(Type stateType, PersistentStateMethod persistentStateMethod);
}
