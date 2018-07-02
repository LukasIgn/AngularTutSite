using System.ComponentModel.DataAnnotations.Schema;

namespace AngularTutSiteApi.Models
{
    public class CurdSnack
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Type { get; set; }
    }
}
 