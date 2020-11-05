using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SlijterijSjonnieLoper.Core
{
    public enum WhiskeyBrand
    {
        [Display(Name="Johnnie Walker")]
        JohnnieWalker,
        Jameson,
        [Display(Name = "Jim Beam")]
        JimBeam,
        [Display(Name = "Jack Daniels")]
        JackDaniels,
        Glenfiddich,
        Yamazaki,
        [Display(Name = "Canadian Club")]
        CanadianClub
    }
}
