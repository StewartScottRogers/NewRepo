using Curl.Protocol.Abstractions;

namespace Curl.Protocol.File;

/// <summary>
/// Serves the <c>file</c> scheme by reading and writing local files through an injected
/// <see cref="IFileSystem" />.
/// </summary>
/// <param name="fileSystem">
/// The file system to open local paths through. No <see cref="FileStream" /> is ever
/// constructed here, so the handler's tests run entirely in memory.
/// </param>
/// <remarks>
/// <see cref="ExecuteAsync(ITransferContext)" /> is not implemented yet: this type is
/// the skeleton the tests are written against first, and it throws
/// <see cref="NotImplementedException" /> on purpose so those tests fail for the stated
/// reason rather than by accident. The transfer itself — the open, the
/// <c>-r</c>/<c>-C</c> seek, the <c>-z</c> condition, the <c>-I</c> pseudo-headers and
/// curl's exit 37-versus-23 split — is backlog item BL-008 in
/// <c>Documentation/Planning/Backlog.md</c>. Do not read a missing behaviour here as an
/// oversight.
/// </remarks>
public sealed class FileProtocolHandler(IFileSystem fileSystem) : IProtocolHandler
{
    /// <summary>
    /// The one scheme this handler serves. Checked against curl 8.21.0's
    /// <c>--version</c> protocol list, which names <c>file</c> and nothing else that
    /// belongs to this library.
    /// </summary>
    private static readonly string[] Schemes = ["file"];

    private readonly IFileSystem fileSystem =
        fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));

    /// <inheritdoc />
    public IReadOnlyCollection<string> SupportedSchemes => Schemes;

    /// <inheritdoc />
    /// <exception cref="NotImplementedException">
    /// Always, for now. The behaviour is deliberately absent until the tests that
    /// describe it exist; see the remarks on <see cref="FileProtocolHandler" />.
    /// </exception>
    public ValueTask<TransferResult> ExecuteAsync(ITransferContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        throw new NotImplementedException(
            "The file:// transfer is not implemented yet; the tests describing it come first.");
    }
}
