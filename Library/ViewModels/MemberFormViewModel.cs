using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.ViewModels
{
    public class MemberFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Member Member { get; set; }
    }
}