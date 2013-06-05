using System.ComponentModel.DataAnnotations;

namespace NUniverse.RomanBookkeeper.WebApplication.Models
{
    public class NumberModel
    {
        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Left Roman operand")]
        [StringLength(20, MinimumLength = 1)]
        public string LeftRomanOperand
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Right Roman operand")]
        [StringLength(20, MinimumLength = 1)]
        public string RightRomanOperand
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Left Arabic operand")]
        [StringLength(20, MinimumLength = 1)]
        public string LeftArabicOperand
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Right Arabic operand")]
        [StringLength(20, MinimumLength = 1)]
        public string RightArabicOperand
        {
            get;
            set;
        }

        public string AdditionResult
        {
            get;
            set;
        }
    }
}