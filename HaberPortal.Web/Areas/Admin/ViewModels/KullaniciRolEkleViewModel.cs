using HaberPortal.Domain.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortal.Web.Areas.Admin.ViewModels
{
    public class KullaniciRolViewModel
    {
        public KullaniciRolViewModel()
        {
            Roller = new List<RolViewModel>();
        }
        public int KullaniciId { get; set; }
        public List<RolViewModel> Roller { get; set; }
    }

    public class RolViewModel
    {
        public bool RoleSahip { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string RolAdi { get; set; }
    }
}