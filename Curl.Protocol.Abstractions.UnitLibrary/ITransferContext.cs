namespace Curl.Protocol.Abstractions;

/// <summary>
/// Everything a protocol handler needs for one transfer, assembled by the command
/// line layer and handed to the handler.
/// </summary>
public interface ITransferContext
{
    /// <summary>
    /// Gets the URL being transferred, after any scheme rewriting has been applied.
    /// </summary>
    Uri Url { get; }

    /// <summary>
    /// Gets the stream that received data is written to.
    /// </summary>
    Stream Output { get; }

    /// <summary>
    /// Gets the stream to upload from, or <see langword="null" /> for a download.
    /// </summary>
    Stream? Upload { get; }

    /// <summary>
    /// Gets the time source. Injected so that timeout and retry behaviour is testable
    /// without a real delay.
    /// </summary>
    TimeProvider TimeProvider { get; }

    /// <summary>
    /// Gets the token that cancels this transfer.
    /// </summary>
    CancellationToken CancellationToken { get; }
}
