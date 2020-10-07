using arsiv.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace arsiv.ViewModels
{
    public class İslemFormViewModel
    {
        public IEnumerable<Uyeler> Uyelers { get; set; }
        public IEnumerable<Kitaplar> Kitaplars { get; set; }
        public İslem İslem { get; set; }
    }
}