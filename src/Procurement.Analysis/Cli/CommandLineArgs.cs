namespace Procurement.Analysis.Cli;

/// <summary>Tiny --flag value parser. Supports "--flag value" and "--flag=value"; flags without a value become "true".</summary>
public sealed class CommandLineArgs
{
    private readonly Dictionary<string, string> _values = new(StringComparer.OrdinalIgnoreCase);

    public CommandLineArgs(IReadOnlyList<string> args)
    {
        for (var i = 0; i < args.Count; i++)
        {
            var arg = args[i];
            if (!arg.StartsWith("--", StringComparison.Ordinal))
                continue;

            var name = arg[2..];
            var eqIndex = name.IndexOf('=');
            if (eqIndex >= 0)
            {
                _values[name[..eqIndex]] = name[(eqIndex + 1)..];
                continue;
            }

            if (i + 1 < args.Count && !args[i + 1].StartsWith("--", StringComparison.Ordinal))
            {
                _values[name] = args[++i];
            }
            else
            {
                _values[name] = "true";
            }
        }
    }

    public string? Get(string name) => _values.GetValueOrDefault(name);

    public string[] GetList(string name) =>
        Get(name)?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries) ?? [];
}
