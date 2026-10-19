# Building BolSno

## Prerequisites

| Tool | Required | Notes |
|------|----------|-------|
| .NET SDK ≥ 10.0 | **Yes** | `dotnet --version` — install from https://dot.net |
| gcc or clang | Optional | Only needed to rebuild native `.so` libs from source |
| F# | Included | Bundled with the .NET SDK — no separate install |
| VB.NET | Included | Bundled with the .NET SDK — no separate install |

**Platform matrix:**

| Platform | Build | Tests | Native libs |
|----------|-------|-------|-------------|
| Linux x64 | ✅ | ✅ | Pre-built `.so` committed |
| Windows x64 | ✅ | ✅ | `.dll` build requires gcc/MSYS2 or cl.exe |
| macOS x64/arm64 | ✅ | ✅ (most) | `.dylib` not yet pre-built; C tests skip |

## Quick Start

```bash
git clone https://github.com/snobol4ever/snobol4dotnet BolSno
cd BolSno

dotnet build BolSno.sln -c Release -p:EnableWindowsTargeting=true
dotnet test TestBolSno/TestBolSno.csproj -c Release -p:EnableWindowsTargeting=true
```

**Always pass `-p:EnableWindowsTargeting=true` on Linux** — the project targets
`net10.0-windows` for some reflection APIs; this flag enables cross-compilation.

Expected: **1873/1876 passed, 0 failed, 3 skipped** (3 C-ABI pin tests [Ignore] on
platforms without matching ABI).

## Native Libraries

Pre-built `.so` files are committed to the repo for Linux x64:

| Library | Source | Purpose |
|---------|--------|---------|
| `CustomFunction/SpitbolCLib/libspitbol_math.so` | `spitbol_math.c` | C-ABI math fixture |
| `CustomFunction/SpitbolNoconvLib/libspitbol_noconv.so` | `spitbol_noconv.c` | noconv pass-through tests |
| `CustomFunction/SpitbolCreateLib/libspitbol_create.so` | `spitbol_create.c` | foreign object creation tests |
| `CustomFunction/SpitbolXnLib/libsnobol4_rt.so` | `snobol4_rt.c` | SPITBOL xn1st/xncbp/xnsave shim |
| `CustomFunction/SpitbolXnLib/libspitbol_xn.so` | `spitbol_xn.c` | xnblk counter fixture |
| `CustomFunction/libsnobol4_rt.so` | `SpitbolXnLib/snobol4_rt.c` | Runtime helper shim |

To rebuild from source (Linux, requires gcc):

```bash
bash build_native.sh
```

## Running Benchmarks

```bash
# Wall-clock runner (no BenchmarkDotNet dependency)
dotnet run --project benchmarks/Benchmarks.csproj -c Release

# Requires snobol4corpus alongside BolSno:
#   git clone https://github.com/snobol4ever/snobol4corpus ../snobol4corpus
# Or set CORPUS env var:
CORPUS=/path/to/snobol4corpus/benchmarks \
  dotnet run --project benchmarks/Benchmarks.csproj -c Release
```

## Project Layout

```
BolSno.sln                  — solution (all projects)
BolSno/                     — main runtime (Executive, Builder, patterns)
BolSno.Common/              — shared types (Var hierarchy, strategies)
TestBolSno/                 — xUnit test suite (~1876 tests)
benchmarks/                  — wall-clock benchmark runner
CustomFunction/              — native + managed external function fixtures
perf/                        — baseline.md + profile docs
corpus/                      — symlink/submodule to snobol4corpus (optional)
```
