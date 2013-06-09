using System.ComponentModel.DataAnnotations;

namespace NUniverse.RomanBookkeeper.WebApplication.Models
{
    public class SummingModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Left operand field is required")]
        public string LeftOperand
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Right operand field is required")]
        public string RightOperand
        {
            get;
            set;
        }
    }
}