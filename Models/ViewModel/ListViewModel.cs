using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.ViewModel
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public int? Edad { get; set; }

        public Nullable<bool> Is_active { get; set; }

    }
}