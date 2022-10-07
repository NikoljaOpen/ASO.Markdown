using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Drawing;
using System.Net.NetworkInformation;
using static System.Windows.Forms.DataFormats;

namespace ASO.Markdown.Extensions;

public class UriFileInfo
{
    public string Uri = string.Empty;

    public string Scheme = string.Empty;

    public string Host = string.Empty;

    public string AbsolutePath = string.Empty;

    public string Query = string.Empty;

    public UriOfType OfType = UriOfType.None;

    public UriExtension Extension = UriExtension.None;


    public UriFileInfo(string uri)
    {
        HttpResponseMessage? request;
        using (var client = new HttpClient())
        {
            request = client.GetAsync(uri).Result;
        }

        if (request != null)
        {
            var requestUri = request.RequestMessage?.RequestUri ?? null;
            if (requestUri != null)
            {
                Host = requestUri.Host ?? string.Empty;
                AbsolutePath = requestUri.AbsolutePath;
                Query = requestUri.Query;
                Scheme = requestUri.Scheme;
            }

            var contentType = request.Content.Headers.ContentType?.MediaType?.Split('/') ?? null;
            if (contentType != null)
            {
                OfType = OfTypeConverter(contentType[0]);
                Extension = OfExtensionConverter(contentType[1]);
            }
        }

        Uri = uri;
    }

    private UriExtension OfExtensionConverter(string value)
    {
        var result = value.ToLower() switch
        {
            "edi-x12" => UriExtension.EdiX12,
            "edifact" => UriExtension.EDIFACT,
            "javascript" => UriExtension.Javascript,
            "octet-stream" => UriExtension.OctetStream,
            "ogg" => UriExtension.Ogg,
            "pdf" => UriExtension.Pdf,
            "xhtml+xml" => UriExtension.XhtmlXml,
            "x-shockwave-flash" => UriExtension.XShockwaveFlash,
            "json" => UriExtension.Json,
            "ld+json" => UriExtension.LdJson,
            "xml" => UriExtension.Xml,
            "zip" => UriExtension.Zip,
            "x-www-form-urlencoded" => UriExtension.XWwwFormUrlencoded,

            "mpeg" => UriExtension.Mpeg,
            "x-ms-wma" => UriExtension.XMsWma,
            "vnd.rn-realaudio" => UriExtension.VndRnRealaudio,
            "x-wav" => UriExtension.XWav,

            "gif" => UriExtension.Gif,
            "jpeg" => UriExtension.Jpeg,
            "png" => UriExtension.Png,
            "tiff" => UriExtension.Tiff,
            "vnd.microsoft.icon" => UriExtension.VndMicrosoftIcon,
            "x-icon" => UriExtension.XIcon,
            "vnd.djvu" => UriExtension.VndDjvu,
            "svg+xml" => UriExtension.SvgXml,

            "mixed" => UriExtension.Mixed,
            "alternative" => UriExtension.Alternative,
            "related" => UriExtension.Related,
            "form-data" => UriExtension.FormData,

            "css" => UriExtension.Css,
            "csv" => UriExtension.Csv,
            "html" => UriExtension.Html,
            "plain" => UriExtension.Plain,

            "mp4" => UriExtension.Mp4,
            "quicktime" => UriExtension.Quicktime,
            "x-ms-wmv" => UriExtension.XMsWmv,
            "x-msvideo" => UriExtension.XMsVideo,
            "x-flv" => UriExtension.XFlv,
            "webm" => UriExtension.Webm,

            "vnd.oasis.opendocument.text" => UriExtension.VndOasisOpendocumentText,
            "vnd.oasis.opendocument.spreadsheet" => UriExtension.VndOasisOpendocumentSpreadsheet,
            "vnd.oasis.opendocument.presentation" => UriExtension.VndOasisOpendocumentPresentation,
            "vnd.oasis.opendocument.graphics" => UriExtension.VndOasisOpendocumentGraphics,
            "vnd.ms-excel" => UriExtension.VndMsExcel,
            "vnd.openxmlformats-officedocument.spreadsheetml.sheet" => UriExtension.VndOpenxmlformatsOfficedocumentSpreadsheetmlSheet,
            "vnd.ms-powerpoint" => UriExtension.VndMsPowerpoint,
            "vnd.openxmlformats-officedocument.presentationml.presentation" => UriExtension.VndOpenxmlformatsOfficedocumentPresentationmlPresentation,
            "msword" => UriExtension.Msword,
            "vnd.openxmlformats-officedocument.wordprocessingml.document" => UriExtension.VndOpenxmlformatsOfficedocumentWordprocessingmlDocument,
            "vnd.mozilla.xul+xml" => UriExtension.VndMozillaXulXml,

            _ => throw new Exception("Не удалось определить формат файла.")
        };

        return result;
    }

    private UriOfType OfTypeConverter(string value)
    {
        var result = value.ToLower() switch
        {
            "application" => UriOfType.Application,
            "audio" => UriOfType.Audio,
            "image" => UriOfType.Image,
            "multipart" => UriOfType.Multipart,
            "text" => UriOfType.Text,
            "video" => UriOfType.Video,
            "vnd" => UriOfType.VND,
            "html" => UriOfType.Html,

            _ => throw new Exception("Не удалось определить тип файла."),
        };

        return result;
    }
}

[Flags]
public enum UriOfType
{
    None = 0,
    Application = 1,
    Audio = 2,
    Image = 4,
    Multipart = 8,
    Text = 16,
    Video = 32,
    VND = 64,
    Html = 128,
}

public enum UriExtension
{
    None,
    
    //      App
    EdiX12,
    EDIFACT,
    Javascript,
    OctetStream,
    Ogg,
    Pdf,
    XhtmlXml,
    XShockwaveFlash,
    Json,
    LdJson,
    Xml,
    Zip,
    XWwwFormUrlencoded,

    //      Audio
    Mpeg,
    XMsWma,
    VndRnRealaudio,
    XWav,

    //      Image
    Gif,
    Jpeg,
    Png,
    Tiff,
    VndMicrosoftIcon,
    XIcon,
    VndDjvu,
    SvgXml,

    //      Multipart
    Mixed,
    Alternative,
    Related,
    FormData,

    //      Text
    Css,
    Csv,
    Html,
    //Javascript,
    Plain,
    //Xml,

    //      Video
    //Mpeg,
    Mp4,
    Quicktime,
    XMsWmv,
    XMsVideo,
    XFlv,
    Webm,

    //VND
    VndOasisOpendocumentText,
    VndOasisOpendocumentSpreadsheet,
    VndOasisOpendocumentPresentation,
    VndOasisOpendocumentGraphics,
    VndMsExcel,
    VndOpenxmlformatsOfficedocumentSpreadsheetmlSheet,
    VndMsPowerpoint,
    VndOpenxmlformatsOfficedocumentPresentationmlPresentation,
    Msword,
    VndOpenxmlformatsOfficedocumentWordprocessingmlDocument,
    VndMozillaXulXml
}