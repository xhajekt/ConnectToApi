using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConnectToApi.Models
{
    public class RegisterViewModel
    {
        [DisplayName("Member name")]
        public string MemberName { get; set; }

        [DisplayName("Watchlist name")]
        public string WatchListName { get; set; }

        //public string ImageName { get; set; }


        [DisplayName("Image")]
        public IFormFile ImageFile { get; set; }

    }
}
