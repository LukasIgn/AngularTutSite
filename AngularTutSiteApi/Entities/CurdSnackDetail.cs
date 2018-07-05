namespace AngularTutSiteApi.Entities
{
    public class CurdSnackDetail
    {
        public long Id { get; set; }

        public string Details { get; set; }

        public virtual CurdSnack CurdSnack { get; set; }
    }
}
