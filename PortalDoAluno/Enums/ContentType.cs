
/// <summary>
/// Courses content format
/// </summary>
public enum ContentType : byte
{
    /// <summary>
    /// Content only in video
    /// </summary>
    VideoOnly = 10,

    /// <summary>
    /// Content only in text
    /// </summary>
    TextOnly = 20,

    /// <summary>
    /// Content in text and video
    /// </summary>
    TextAndVideo = 30
}