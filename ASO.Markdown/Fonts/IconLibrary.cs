using System.Collections.Generic;

namespace ASO.Markdown;

public enum IconType
{
    None,
    ArrowLeft,
    Calendar,
    Check,
    ChevronDown,
    Filter,
    FilterSlash,
    Pencil,
    Plus,
    Search,
    Times,
    User,
    Code,
    Link,
    Table,
    Image,
    Save,
    File,
    Question,
    Undo,
    Redo,
    BulletedLis,
    AlignCenter,
    AlignRight,
    AlignLeft,
    Play,
    Pause,
    VolumeUp
}

public static class IconLibrary
{
    public readonly static Dictionary<IconType, string> Icons = new()
    {
        [IconType.None]         = "",
        [IconType.ArrowLeft]    = "\ue91a",
        [IconType.Calendar]     = "\ue927",
        [IconType.Check]        = "\ue909",
        [IconType.ChevronDown]  = "\ue902",
        [IconType.Filter]       = "\ue94c",
        [IconType.FilterSlash]  = "\ue9b7",
        [IconType.Pencil]       = "\ue942",
        [IconType.Plus]         = "\ue90d",
        [IconType.Search]       = "\ue908",
        [IconType.Times]        = "\ue90b",
        [IconType.User]         = "\ue939",
        [IconType.Code]         = "\ue9e7",
        [IconType.Link]         = "\ue9c1",
        [IconType.Table]        = "\ue969",
        [IconType.Image]        = "\ue972",
        [IconType.Save]         = "\ue95b",
        [IconType.File]         = "\ue958",
        [IconType.Question]     = "\ue959",
        [IconType.Undo]         = "\ue94d",
        [IconType.Redo]         = "\ue938",
        [IconType.BulletedLis]  = "\ue967",
        [IconType.AlignCenter]  = "\ue948",
        [IconType.AlignLeft]    = "\ue947",
        [IconType.AlignRight]   = "\ue946",
        [IconType.Play]         = "\ue9b3",
        [IconType.Pause]        = "\ue9b2",
        [IconType.VolumeUp]     = "\ue977"
    };
}

