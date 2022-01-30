using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectToApi.Models
{
    public class SearchViewModel
    {
        [DisplayName("Name of watchlist")]
        public string WatchlistName { get; set; }
        
        public int Treshold { get; set; }
        
        [DisplayName("Image")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Min face size")]
        public int MinFaceSize { get; set; }

        [DisplayName("Max face size")]
        public int MaxFaceSize { get; set; }

    }
}
