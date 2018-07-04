namespace AngularTutSiteApi.Entities
{
    public class CurdSnack
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Type { get; set; }

        public int DetailForeignKey { get; set; }

        public CurdSnackDetail Detail { get; set; }
    }
}
 