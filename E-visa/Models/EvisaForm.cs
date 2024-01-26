using Microsoft.AspNetCore.SignalR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace E_Visa.Models
{
    public class EvisaForm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Portrait format is required")]
        [Display(Name = "Portrait format")]
        public string PortraitFormat { get; set; }

        [Required(ErrorMessage = "Passport Front Page is required")]
        [Display(Name = "Passport Front Page")]
        public string PassportFrontPage { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [Display(Name = "Surname")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Given name is required")]
        [Display(Name = "GivenName")]
        public string GivenName { get; set; }

        [Required(ErrorMessage = "Visa type is required")]
        [Display(Name = "Type of Visa Required")]
        public VisaType VisaType { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Place of Birth")]
        public string? PlaceOfBirth { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        [Display(Name = "Current Nationality")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Permanent residential address is required")]
        [Display(Name = "Permanent Residential Address")]
        public string ResidentialAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Religion is required")]
        [Display(Name = "Religion")]
        public string Religion { get; set; }

        [Display(Name = "Occupation")]
        public string? Occupation { get; set; }

        [Display(Name = "Name of working company/School")]
        public string? OccupationCompanyName{ get; set; }

        [Display(Name = "Occupation/School/College Address")]
        public string? OccupationCompanyAddress { get; set; }

        [Required(ErrorMessage = "Pasport number is required")]
        [Display(Name = "Passport Number")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Pasport type is required")]
        [Display(Name = "Passport Type")]
        public PassportType PassportType { get; set; }

        [Display(Name = "Place of Issue")]
        public string? PlaceIssue { get; set; }

        [Required(ErrorMessage = "Intended Arrival Date is required")]
        [Display(Name = "Intended Arrival Date")]
        
        public string IntendedArrivalDate { get; set; }

        [Required(ErrorMessage = "Passport Issue Date is required")]
        [Display(Name = "Passport Issue Date")]
        
        public string PassportIssueDate { get; set; }

        [Required(ErrorMessage = "Passport Expiry Date is required")]
        [Display(Name = "Passport Expiry Date")]
        
        public string PassportExpiryDate { get; set; }

        [Display(Name = "Do you have any other valid passports?")]
        public int OtherPassport { get; set; }

        [ConditionalRequired("OtherPassport", 0, ErrorMessage = "Pasport number is required")]
        [Display(Name = "Passport No")]
        public string? PassportOtherNo { get; set; }

        [ConditionalRequired("OtherPassport", 0, ErrorMessage = "Issuing Authority/Place of issue is required")]
        [Display(Name = "Issuing Authority/Place of issue")]
        public string? PlaceOtherIssue { get; set; }

        [ConditionalRequired("OtherPassport", 0, ErrorMessage = "Issue Date is required")]
        [Display(Name = "Issue Date")]
        
        public string? OtherIssueDate { get; set; }

        [ConditionalRequired("OtherPassport", 0, ErrorMessage = "Expiry Date is required")]
        [Display(Name = "Expiry Date")]
        
        public string? OtherIssueExpiryDate { get; set; }

        [Display(Name = "Have you previously utilized different passports for entry into Vietnam?")]
        public int BeenToVietNam { get; set; }

        [ConditionalRequired("BeenToVietNam", 0, ErrorMessage = "Pasport number is required")]
        [Display(Name = "Passport No")]
        public string? PassportBeenToVietNamNo { get; set; }

        [ConditionalRequired("BeenToVietNam", 0, ErrorMessage = "FullName is required")]
        [Display(Name = "FullName")]
        public string? BeenToVietNamFullName { get; set; }

        [ConditionalRequired("BeenToVietNam", 0, ErrorMessage = "Date of Birth is required")]
        [Display(Name = "Issue Date")]
        
        public string? BeenToVietNamDateOfBirth { get; set; }

        [ConditionalRequired("BeenToVietNam", 0, ErrorMessage = "Nationality  is required")]
        [Display(Name = "Nationality ")]
        public string? BeenToVietNamNationality { get; set; }

        [Display(Name = "Do you have multiple or dual nationalities?")]
        public int MultipleNationality { get; set; }

        public string? EnterOtherNationality { get; set; }

        [Display(Name = "Have you been visited to Viet Nam in the last 01 year period?")]
        public int VisitedVietNam { get; set; }

        [Display(Name = "From")]
        
        public string? VisitedVietNamFrom { get; set; }

        [Display(Name = "To")]
        
        public string? VisitedVietNamTo { get; set; }

        [Display(Name = "Purpose")]
        public string? VisitedVietNamPurpose { get; set; }

        [Display(Name = "Intended length of stay in Viet Nam (number of days)")]
        [Required(ErrorMessage = "Length of Stay is required")]
        public int LengthOfStay { get; set; }

        [Display(Name = "Purpose of visit")]
        [Required(ErrorMessage = "Purpose of visit is required")]
        public string PurposeOfVisit { get; set; }

        [Display(Name = "Intended temporary residential address in Viet Nam")]
        [Required(ErrorMessage = "Intended temporary residential address in Viet Nam is required")]
        public string IntendedAddress { get; set; }

        [Display(Name = "Grant Evisa valid from")]
        
        public string? GrantEvisa { get; set; }

        [Display(Name = "To")]
        
        public string? GrantEvisaTo { get; set; }

        [Display(Name = "Allowed to entry through checkpoint")]
        [Required(ErrorMessage = "Allowed to entry through checkpoint is required")]
        public AirportType EntryGate { get; set; }

        [Display(Name = "Exit through checkpoint")]
        [Required(ErrorMessage = "Exit through checkpoint is required")]
        public AirportType ExitGate { get; set; }

        [Display(Name = "Intended expenses (in USD)")]
        public float? IntendedExpenses { get; set; }

        [Display(Name = "All Trip expenses are borne by")]
        public int? ExpensesBy { get; set; }

        [Display(Name = "Do you have health insurance arranged for your trip in Viet Nam?")]
        public int? HealthInsurance { get; set; }

        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }

    public enum VisaType : int
    {
        [Display(Name = "Single entry visa")]
        SingleEntryVisa = 0,
        [Display(Name = "Multiple entry visa")]
        MultipleEntryVisa = 1,
    }

    public enum Gender : int
    {
        [Display(Name = "Male")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1,
    }

    public enum PassportType : int
    {
        [Display(Name = "Diplomatic passport")]
        DiplomaticPassport = 0,
        [Display(Name = "Official passport")]
        OfficialPassport = 1,
        [Display(Name = "Ordinary passport")]
        OrdinaryPassport = 2,
    }

    public enum AirportType : int
    {
        [Display(Name = "Can Tho International Airport")]
        CanThoInternationalAirport = 0,
        [Display(Name = "Da Nang International Airport")]
        DaNangInternationalAirport = 1,
        [Display(Name = "Noi Bai Int Airport")]
        NoiBaiInternationalAirport = 2,
        [Display(Name = "Phu Bai Int Airport")]
        PhuBaiInternationalAirport = 3,
        [Display(Name = "Phu Quoc International Airport")]
        PhuQuocInternationalAirport = 4,
        [Display(Name = "Cat Bi Int Airport(Hai Phong)")]
        CatBiInternationalAirport = 5,
        [Display(Name = "Tan Son Nhat Int Airport(Ho Chi Minh City)")]
        TanSonNhatInternationalAirport = 6,
        [Display(Name = "Cam Ranh Int Airport(Khanh Hoa)")]
        CamRanhInternationalAirport = 7,
        [Display(Name = "Nam Can Landport")]
        NamCanLandport = 8,
        [Display(Name = "Song Tien Landport")]
        SongTienLandport = 9,
        [Display(Name = "Tinh Bien Landport")]
        TinhBienLandport = 10,
        [Display(Name = "Xa Mat Landport")]
        XaMatLandport = 11,
        [Display(Name = "Mong Cai Landport")]
        MongCaiLandport = 12,
        [Display(Name = "Moc Bai Landport")]
        MocBaiLandport = 13,
        [Display(Name = "Lao Bao Landport")]
        LaoBaoLandport = 14,
        [Display(Name = "Ha Tien Landport")]
        HaTienLandport = 15,
        [Display(Name = "Huu Nghi Landport")]
        HuuNghiLandport = 16,
        [Display(Name = "Cau Treo Landport")]
        CauTreoLandport = 17,
        [Display(Name = "Cha Lo Landport")]
        ChaLoLandport = 18,
        [Display(Name = "Bo Y Landport")]
        BoYLandport = 19,
        [Display(Name = "Lao Cai Landport")]
        LaoCaiLandport = 20,
        [Display(Name = "Seaport Ho Chi Minh City")]
        SeaportHoChiMinhCity = 21,
        [Display(Name = "Quy Nhon Seaport")]
        QuyNhonSeaport = 22,
        [Display(Name = "Nha Trang Seaport")]
        NhaTrangSeaport = 23,
        [Display(Name = "Hai Phong Seaport")]
        HaiPhongSeaport = 24,
        [Display(Name = "Hon Gai Seaport")]
        HonGaiSeaport = 25,
        [Display(Name = "Da Nang Seaport")]
        DaNangSeaport = 26,
        [Display(Name = "Vung Tau Seaport")]
        VungTauSeaport = 27,
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ConditionalRequiredAttribute : ValidationAttribute
    {
        private readonly string _dependentPropertyName;
        private readonly object _targetValue;

        public ConditionalRequiredAttribute(string dependentPropertyName, object targetValue)
        {
            _dependentPropertyName = dependentPropertyName;
            _targetValue = targetValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dependentProperty = validationContext.ObjectType.GetProperty(_dependentPropertyName);

            if (dependentProperty == null)
            {
                return new ValidationResult($"Unknown property {_dependentPropertyName}");
            }

            var dependentValue = dependentProperty.GetValue(validationContext.ObjectInstance, null);

            if (dependentValue != null && Equals(dependentValue, _targetValue))
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} is required.");
                }
            }

            return ValidationResult.Success;
        }
    }

}
