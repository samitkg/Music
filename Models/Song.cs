using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MusicApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
    }
}