using VideoPortal.Helpers.ValidationAttributes;

namespace VideoPortal.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}