﻿using MusicApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Services.Interfaces
{
    public interface ISongService
    {
        IEnumerable<SongDisplayResponse> GetSongsForList();
        IEnumerable<SongDisplayResponse> GetSongsOfAlbum(int albumId);
    }
}
