using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с исполнителями
    /// </summary>
    public partial class YArtistAPI : YCommonAPI
    {
        #region Основные функции

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistId">Идентификатор</param>
        public YResponse<YArtistBriefInfo> Get(AuthStorage storage, string artistId)
        {
            return GetAsync(storage, artistId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistIds">Идентификаторы</param> 
        public YResponse<List<YArtist>> Get(AuthStorage storage, IEnumerable<string> artistIds)
        {
            return GetAsync(storage, artistIds).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}