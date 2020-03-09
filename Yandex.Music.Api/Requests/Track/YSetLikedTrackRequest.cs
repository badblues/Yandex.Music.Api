using System.Collections.Generic;
using System.Net;

using Yandex.Music.Api.Common;

namespace Yandex.Music.Api.Requests.Track
{
    internal class YSetLikedTrackRequest : YRequest
    {
        public YSetLikedTrackRequest(YAuthStorage storage) : base(storage)
        {
        }

        public YRequest Create(bool status, string trackKey)
        {
            var time = storage.Context.GetTimeInterval().ToString();

            var take = "add";
            if (!status)
                take = "remove";

            var query = new Dictionary<string, string> {
                {"from", "web-own_tracks-track-track-main"},
                {"sign", storage.User.Sign},
                {"external-domain", "music.yandex.ru"},
                {"overembed", "no"}
            };

            var url = $"https://music.yandex.ru/api/v2.1/handlers/track/{trackKey}/web-own_tracks-track-track-main/like/{take}?__t={time}";

            var headers = new List<KeyValuePair<string, string>> {
                YRequestHeaders.Get(YHeader.Accept, storage),
                YRequestHeaders.Get(YHeader.AcceptCharset, storage),
                YRequestHeaders.Get(YHeader.AcceptEncoding, "utf-8"),
                YRequestHeaders.Get(YHeader.AcceptLanguage, storage),
                YRequestHeaders.Get(YHeader.AccessControlAllowMethods, storage),
                YRequestHeaders.Get(YHeader.ContentType, "application/x-www-form-urlencoded; charset=UTF-8"),
                YRequestHeaders.Get(YHeader.Origin, storage),
                YRequestHeaders.Get(YHeader.Referer, storage),
                YRequestHeaders.Get(YHeader.SecFetchMode, storage),
                YRequestHeaders.Get(YHeader.SecFetchSite, storage),
                YRequestHeaders.Get(YHeader.XCurrentUID, storage),
                YRequestHeaders.Get(YHeader.XRequestedWith, storage),
                YRequestHeaders.Get(YHeader.XRetpathY, storage)
            };

            FormRequest(url, body: GetQueryString(query), headers: headers, method: WebRequestMethods.Http.Post);

            return this;
        }
    }
}