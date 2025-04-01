using System.ComponentModel.DataAnnotations;

namespace _06_ASPNET.Models
{
    public class Uzivatel
    {
        public int Id { get; set; }

        public string Jmeno { get; set; }

        public string Heslo { get; set; }
    }
}
