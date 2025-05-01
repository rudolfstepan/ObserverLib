# ObserverLib

Eine eigenständige .NET-Bibliothek mit verschiedenen Varianten des Observer-Patterns – ohne zentrale Listener-Liste.

## Features

- `MemoryObserver<T>`: nutzt `WaitOnAddress`/`WakeByAddressAll` (nur Windows)
- `SpinObserver`: plattformunabhängig, lockfrei, sehr leichtgewichtig
- Demo-App und Unit-Tests enthalten

## Demo

```bash
dotnet run --project ObserverLib.Demo
```

## Tests

```bash
dotnet test
```

## Lizenz

MIT License