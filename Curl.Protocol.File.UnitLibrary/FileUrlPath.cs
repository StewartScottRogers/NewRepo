using System.Diagnostics.CodeAnalysis;

namespace Curl.Protocol.File;

/// <summary>
/// The path half of a <c>file://</c> URL, in both of the forms curl needs it: as written
/// in the URL, and as handed to the operating system.
/// </summary>
/// <param name="UrlPath">
/// The path exactly as it appears in the URL, still percent-encoded. This is the text
/// curl echoes in its exit 37 message, so it has to survive parsing unaltered rather than
/// be reconstructed from the decoded form.
/// </param>
/// <param name="OsPath">
/// The percent-decoded operating-system path handed to
/// <see cref="Abstractions.IFileSystem" />. Directory separators are the platform's, and
/// no <c>.</c> or <c>..</c> segment has been resolved.
/// </param>
/// <remarks>
/// <para>
/// Parsing works from <see cref="Uri.OriginalString" />, never
/// <see cref="Uri.AbsolutePath" /> and never <see cref="Uri.LocalPath" />. Those two
/// normalise <c>..</c> away, rewrite <c>c|</c> to <c>c:</c>, and fold
/// <c>file:////server/share</c> into a UNC authority — none of which curl does. The
/// measurements behind that are recorded in ADR-0003
/// (<c>Documentation/Planning/Decisions</c>), taken against curl 8.21.0.
/// </para>
/// <para>
/// <see cref="TryParse(Uri, out FileUrlPath)" /> is not implemented yet: this type is a
/// skeleton written for the tests to be authored against, and its body throws
/// <see cref="NotImplementedException" /> on purpose. The algorithm it will implement
/// belongs to backlog item BL-008 in <c>Documentation/Planning/Backlog.md</c>; the wider
/// question of URLs <see cref="Uri" /> cannot round-trip at all is BL-010.
/// </para>
/// </remarks>
public sealed record FileUrlPath(string UrlPath, string OsPath)
{
    /// <summary>
    /// Extracts the URL path and the operating-system path from a <c>file://</c> URL.
    /// </summary>
    /// <param name="url">The URL to read. Its scheme must be <c>file</c>.</param>
    /// <param name="path">
    /// On success, the parsed pair; otherwise undefined and not to be read.
    /// </param>
    /// <returns>
    /// <see langword="true" /> when <paramref name="url" /> is a <c>file://</c> URL whose
    /// path curl would accept; <see langword="false" /> when the caller should report
    /// <see cref="Abstractions.CurlExitCode.UrlMalformat" />.
    /// </returns>
    /// <remarks>
    /// <para>
    /// The seven steps, in order:
    /// </para>
    /// <list type="number">
    /// <item>
    /// <description>
    /// <strong>Scheme.</strong> Compare the scheme to <c>file</c> ignoring case with an
    /// ordinal comparison. Anything else returns <see langword="false" />; this type
    /// never guesses a scheme.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <strong>Take the original text.</strong> Work on the remainder of
    /// <see cref="Uri.OriginalString" /> after the leading <c>file:</c>, verbatim.
    /// <see cref="Uri.AbsolutePath" /> and <see cref="Uri.LocalPath" /> are both
    /// off-limits, for the reasons in the remarks on <see cref="FileUrlPath" />.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <strong>Authority.</strong> When the remainder starts with <c>//</c>, the
    /// characters up to the next <c>/</c> are the authority. An empty authority
    /// (<c>file:///tmp/x</c>) and <c>localhost</c> compared ignoring case
    /// (<c>file://localhost/tmp/x</c>) are both dropped, leaving the path that follows.
    /// Any other authority returns <see langword="false" />: curl does not support a
    /// host part in a <c>file://</c> URL.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <strong>The UNC form.</strong> <c>file:////server/share</c> leaves
    /// <c>//server/share</c> once its empty authority is dropped. Both leading slashes
    /// are kept: this is the one UNC spelling curl accepts, and collapsing them would
    /// turn a network path into a local one.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <strong>Drive letters.</strong> A path of the form <c>/X:/…</c> or <c>/X|/…</c>,
    /// where <c>X</c> is a single ASCII letter, loses its leading slash so that
    /// <c>file:///c:/Windows/win.ini</c> becomes an absolute Windows path. The <c>|</c>
    /// spelling is preserved as written and not translated to <c>:</c>, because
    /// translating it is a <see cref="Uri.LocalPath" /> behaviour that curl does not
    /// share (ADR-0003).
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <strong>Decode.</strong> <c>UrlPath</c> is the result of steps three to five,
    /// still encoded. <c>OsPath</c> is that text with each <c>%XX</c> escape decoded to
    /// the byte it names, including <c>%2F</c> to a literal <c>/</c>; a malformed escape
    /// is left exactly as written rather than rejected, which is what curl passes to the
    /// operating system.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <strong>Hand over unnormalised.</strong> Convert <c>/</c> to the platform
    /// directory separator in <c>OsPath</c>, and stop there: no <c>.</c> or <c>..</c>
    /// segment is resolved, no trailing separator is trimmed and no case is changed. curl
    /// gives the path to the operating system as the user wrote it. An empty path after
    /// all of this returns <see langword="false" />.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="url" /> is <see langword="null" />.
    /// </exception>
    /// <exception cref="NotImplementedException">
    /// Always, for now. The algorithm above is deliberately absent until the tests that
    /// describe it exist.
    /// </exception>
    public static bool TryParse(Uri url, [MaybeNullWhen(false)] out FileUrlPath path)
    {
        ArgumentNullException.ThrowIfNull(url);

        throw new NotImplementedException(
            "file:// URL path parsing is not implemented yet; the tests describing it come first.");
    }
}
