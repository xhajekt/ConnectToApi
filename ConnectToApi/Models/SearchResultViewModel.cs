using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConnectToApi.Models
{
    public class SearchResultViewModel : SearchViewModel
    {
        public List<SearchViewModel> TableData { get; set; }

    }
}
