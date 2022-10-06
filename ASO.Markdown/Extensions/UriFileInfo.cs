using System;
using System.ComponentModel.DataAnnotations;

namespace ASO.Markdown.Extensions;

public class UriFileInfo
{
    public UriOfType OfType = UriOfType.None;

    public UriExtension Extension = UriExtension.None;


    public UriFileInfo(string uri)
    {
        System.Net.WebRequest req = System.Net.HttpWebRequest.Create(uri);
        req.Method = "HEAD";
        using (System.Net.WebResponse resp = req.GetResponse())
        {
            var contentType = resp.ContentType.Split('/');

            OfType = OfTypeConverter(contentType[0]);
            Extension = OfExtensionConverter(contentType[1]);
        }
    }

    private UriExtension OfExtensionConverter(string value)
    {
        var result = value.ToLower() switch
        {
            "mp4" => UriExtension.MP4,
            _ => throw new Exception("Не удалось определить формат файла.")
        };

        return result;
    }

    private UriOfType OfTypeConverter(string value)
    {
        var result = value.ToLower() switch
        {
            "video" => UriOfType.Video,
            "image" => UriOfType.Image,
            _ => throw new Exception("Не удалось определить тип файла."),
        };

        return result;
    }
}

public enum UriOfType
{
    None = 0,
    Image = 1,
    Video = 2,
}

public enum UriExtension
{
    None = 0,
    MP4 = 1,
}