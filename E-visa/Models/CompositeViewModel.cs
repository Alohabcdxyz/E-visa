using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Visa.Models
{
    public class CompositeViewModel
    {
        public EvisaForm EvisaForm { get; set; }
        public EvisaFormVM EvisaFormVM { get; set; }
    }
}
