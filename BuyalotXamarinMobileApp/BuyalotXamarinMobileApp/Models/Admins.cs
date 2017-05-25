using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyalotXamarinMobileApp.Models
{
    public class Admins
    {
        [PrimaryKey, AutoIncrement]
        public int AdminId
        { get; set; }

        [NotNull]
        public string AdminName
        { get; set; }
        public string Username
        { get; set; }
        public string Email
        { get; set; }
        public string Password
        { get; set; }
    }
}