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
    User
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
        [IconType.User]         = "\ue939"
    };
}

