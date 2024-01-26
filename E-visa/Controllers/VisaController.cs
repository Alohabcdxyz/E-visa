using AutoMapper;
using E_Visa.Data;
using E_Visa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace E_Visa.Controllers
{
    [Authorize]
    public class VisaController : Controller
    {
        private readonly EvisaDbContext _context;
        public VisaController(EvisaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Consumes("multipart/form-data")]
        [HttpPost]
        public async Task<ActionResult<EvisaForm>> PostApplicationForm([FromForm] EvisaFormVM _profile)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

                var profile = new EvisaForm
                {
                    SurName = _profile.SurName,
                    GivenName = _profile.GivenName,
                    VisaType = _profile.VisaType,
                    Gender = _profile.Gender,
                    DateOfBirth = _profile.DateOfBirth,
                    PlaceOfBirth = _profile.PlaceOfBirth,
                    Nationality = _profile.Nationality,
                    ResidentialAddress = _profile.ResidentialAddress,
                    PhoneNumber = _profile.PhoneNumber,
                    Email = _profile.Email,
                    Religion = _profile.Religion,
                    Occupation = _profile.Occupation,
                    OccupationCompanyAddress = _profile.OccupationCompanyAddress,
                    OccupationCompanyName = _profile.OccupationCompanyName,
                    PassportNumber = _profile.PassportNumber,
                    PassportType = _profile.PassportType,
                    PlaceIssue = _profile.PlaceIssue,
                    IntendedArrivalDate = _profile.IntendedArrivalDate,
                    PassportIssueDate = _profile.PassportIssueDate,
                    PassportExpiryDate = _profile.PassportExpiryDate,
                    OtherPassport = _profile.OtherPassport,
                    PassportOtherNo = _profile.PassportOtherNo,
                    PlaceOtherIssue = _profile.PlaceOtherIssue,
                    OtherIssueDate = _profile.OtherIssueDate,
                    OtherIssueExpiryDate = _profile.OtherIssueExpiryDate,
                    BeenToVietNam = _profile.BeenToVietNam,
                    PassportBeenToVietNamNo = _profile.PassportBeenToVietNamNo,
                    BeenToVietNamFullName = _profile.BeenToVietNamFullName,
                    BeenToVietNamDateOfBirth = _profile.BeenToVietNamDateOfBirth,
                    BeenToVietNamNationality = _profile.BeenToVietNamNationality,
                    MultipleNationality = _profile.MultipleNationality,
                    EnterOtherNationality = _profile.EnterOtherNationality,
                    VisitedVietNam = _profile.VisitedVietNam,
                    VisitedVietNamFrom = _profile.VisitedVietNamFrom,
                    VisitedVietNamTo = _profile.VisitedVietNamTo,
                    VisitedVietNamPurpose = _profile.VisitedVietNamPurpose,
                    LengthOfStay = _profile.LengthOfStay,
                    PurposeOfVisit = _profile.PurposeOfVisit,
                    IntendedAddress = _profile.IntendedAddress,
                    GrantEvisa = _profile.GrantEvisa,
                    GrantEvisaTo = _profile.GrantEvisaTo,
                    EntryGate = _profile.EntryGate,
                    ExitGate = _profile.ExitGate,
                    IntendedExpenses = _profile.IntendedExpenses,
                    ExpensesBy = _profile.ExpensesBy,
                    HealthInsurance = _profile.HealthInsurance,
                    AppUserId = userId,
                    PortraitFormat = await ConvertImageBase.ImageToBase64(_profile.PortraitFormatImage),
                    PassportFrontPage = await ConvertImageBase.ImageToBase64(_profile.PassportFrontPageImage),
                };

                await _context.EvisaForm.AddAsync(profile);
                await _context.SaveChangesAsync();

            return RedirectToAction("FormHistory");
        }

        public async Task<ActionResult> FormHistory()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            var profile = await _context.EvisaForm
                .Where(e => e.AppUserId == userId)
                .OrderByDescending(e => e.Id) 
                .ToListAsync();

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsForm(int id)
        {
            var profile = await _context.EvisaForm.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var profile = await _context.EvisaForm.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            _context.EvisaForm.Remove(profile);
            await _context.SaveChangesAsync();

            return RedirectToAction("FormHistory"); 
        }

        [HttpGet]
        public async Task<IActionResult> EditApplicationForm(int id)
        {
            var profile = await _context.EvisaForm.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> EditApplicationForm([FromRoute] int id, [FromForm] EvisaFormVM _profile)
        {
            var profile = await _context.EvisaForm.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }
            if (_profile.MultipleNationality == 1)
            {
                _profile.EnterOtherNationality = "";
            }
            if (_profile.OtherPassport == 1)
            {
                _profile.PassportOtherNo = "";
                _profile.PlaceOtherIssue = "";
                _profile.OtherIssueDate = "";
                _profile.OtherIssueExpiryDate = "";
            }
            if (_profile.BeenToVietNam == 1)
            {
                _profile.PassportBeenToVietNamNo = "";
                _profile.BeenToVietNamFullName = "";
                _profile.BeenToVietNamDateOfBirth = "";
                _profile.BeenToVietNamNationality = "";
            }
            if (_profile.VisitedVietNam == 1)
            {
                _profile.VisitedVietNamFrom = "";
                _profile.VisitedVietNamTo = "";
                _profile.VisitedVietNamPurpose = "";
            }

            profile.SurName = _profile.SurName;
            profile.GivenName = _profile.GivenName;
            profile.VisaType = _profile.VisaType;
            profile.Gender = _profile.Gender;
            profile.DateOfBirth = _profile.DateOfBirth;
            profile.PlaceOfBirth = _profile.PlaceOfBirth;
            profile.Nationality = _profile.Nationality;
            profile.ResidentialAddress = _profile.ResidentialAddress;
            profile.PhoneNumber = _profile.PhoneNumber;
            profile.Email = _profile.Email;
            profile.Religion = _profile.Religion;
            profile.Occupation = _profile.Occupation;
            profile.OccupationCompanyAddress = _profile.OccupationCompanyAddress;
            profile.OccupationCompanyName = _profile.OccupationCompanyName;
            profile.PassportNumber = _profile.PassportNumber;
            profile.PassportType = _profile.PassportType;
            profile.PlaceIssue = _profile.PlaceIssue;
            profile.IntendedArrivalDate = _profile.IntendedArrivalDate;
            profile.PassportIssueDate = _profile.PassportIssueDate;
            profile.PassportExpiryDate = _profile.PassportExpiryDate;
            profile.OtherPassport = _profile.OtherPassport;
            profile.PassportOtherNo = _profile.PassportOtherNo;
            profile.PlaceOtherIssue = _profile.PlaceOtherIssue;
            profile.OtherIssueDate = _profile.OtherIssueDate;
            profile.OtherIssueExpiryDate = _profile.OtherIssueExpiryDate;
            profile.BeenToVietNam = _profile.BeenToVietNam;
            profile.PassportBeenToVietNamNo = _profile.PassportBeenToVietNamNo;
            profile.BeenToVietNamFullName = _profile.BeenToVietNamFullName;
            profile.BeenToVietNamDateOfBirth = _profile.BeenToVietNamDateOfBirth;
            profile.BeenToVietNamNationality = _profile.BeenToVietNamNationality;
            profile.MultipleNationality = _profile.MultipleNationality;
            profile.EnterOtherNationality = _profile.EnterOtherNationality;
            profile.VisitedVietNam = _profile.VisitedVietNam;
            profile.VisitedVietNamFrom = _profile.VisitedVietNamFrom;
            profile.VisitedVietNamTo = _profile.VisitedVietNamTo;
            profile.VisitedVietNamPurpose = _profile.VisitedVietNamPurpose;
            profile.LengthOfStay = _profile.LengthOfStay;
            profile.PurposeOfVisit = _profile.PurposeOfVisit;
            profile.IntendedAddress = _profile.IntendedAddress;
            profile.GrantEvisa = _profile.GrantEvisa;
            profile.GrantEvisaTo = _profile.GrantEvisaTo;
            profile.EntryGate = _profile.EntryGate;
            profile.ExitGate = _profile.ExitGate;
            profile.IntendedExpenses = _profile.IntendedExpenses;
            profile.ExpensesBy = _profile.ExpensesBy;
            profile.HealthInsurance = _profile.HealthInsurance;
            //profile.PortraitFormat = await ConvertImageBase.ImageToBase64(_profile.PortraitFormatImage);
            //profile.PassportFrontPage = await ConvertImageBase.ImageToBase64(_profile.PassportFrontPageImage);
    

            await _context.SaveChangesAsync();

            return RedirectToAction("DetailsForm", new { id = profile.Id });
        }

        public async Task<IActionResult> Payment(int id)
        {
            var profile = await _context.EvisaForm.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        public async Task<IActionResult> Done(int id)
        {
            var profile = await _context.EvisaForm.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return View(profile);
        }

        public async Task<IActionResult> PrintForm(int id)
        {
            var userData = await _context.EvisaForm.FindAsync(id);

            var filePath = Path.Combine(Path.GetTempPath(), $"Form_{userData.Id}.docx");

            using (var doc = DocX.Create(filePath))
            {
                var defaultSpacingAfter = 15;
                var defaultFont = new Xceed.Document.NET.Font("Times New Roman");
                doc.InsertParagraph("User Information").FontSize(18).Bold().Alignment = Alignment.center;
                if (!string.IsNullOrEmpty(userData.PortraitFormat))
                {
                    var imageStream = new MemoryStream(Convert.FromBase64String(userData.PortraitFormat));
                    var image = doc.AddImage(imageStream);
                    var picture = image.CreatePicture();
                    picture.Height = 100;
                    picture.Width = 75;
                    doc.InsertParagraph($"Portrait format:");
                    doc.InsertParagraph().InsertPicture(picture);
                }
                if (!string.IsNullOrEmpty(userData.PassportFrontPage))
                {
                    var imageStream = new MemoryStream(Convert.FromBase64String(userData.PassportFrontPage));
                    var image = doc.AddImage(imageStream);
                    var picture = image.CreatePicture();
                    picture.Height = 100;
                    picture.Width = 154;
                    doc.InsertParagraph($"Passport Front Page:");
                    doc.InsertParagraph().InsertPicture(picture);
                }
                doc.InsertParagraph($"Type of Visa Required: {userData.VisaType}");
                doc.InsertParagraph($"Surname: {userData.SurName}");
                doc.InsertParagraph($"Given Name: {userData.GivenName}");
                doc.InsertParagraph($"Gender: {userData.Gender}");
                doc.InsertParagraph($"Date of Birth: {userData.DateOfBirth}");
                doc.InsertParagraph($"Place of Birth: {userData.PlaceOfBirth}");
                doc.InsertParagraph($"Current nationality: {userData.Nationality}");
                doc.InsertParagraph($"Permanent Residential Address: {userData.ResidentialAddress}");
                doc.InsertParagraph($"Phone Number: {userData.PhoneNumber}");
                doc.InsertParagraph($"Email: {userData.Email}");
                doc.InsertParagraph($"Religion: {userData.Religion}");
                doc.InsertParagraph($"Occupation: {userData.Occupation}");
                doc.InsertParagraph($"Name of working company/School: {userData.OccupationCompanyName}");
                doc.InsertParagraph($"Occupation/School/College Address: {userData.OccupationCompanyAddress}");

                doc.InsertParagraph("Passport Information").FontSize(18).Bold().Alignment = Alignment.center;
                doc.InsertParagraph($"Passport number: {userData.PassportNumber}");
                doc.InsertParagraph($"Passport Type: {userData.PassportType}");
                doc.InsertParagraph($"Place of Issue: {userData.PlaceIssue}");
                doc.InsertParagraph($"Intended Arrival Date: {userData.IntendedArrivalDate}");
                doc.InsertParagraph($"Passport Issue Date: {userData.PassportIssueDate}");
                doc.InsertParagraph($"Passport Expiry Date: {userData.PassportExpiryDate}");

                doc.InsertParagraph("More Information").FontSize(18).Bold().Alignment = Alignment.center;
                doc.InsertParagraph($"Another valid passports: {(userData.OtherPassport == 0 ? "Yes" : "No")}");
                if(userData.OtherPassport == 0)
                {
                    doc.InsertParagraph($"Passport No: {userData.PassportOtherNo}");
                    doc.InsertParagraph($"Issuing Authority/Place of issue: {userData.PlaceOtherIssue}");
                    doc.InsertParagraph($"Issue Date: {userData.OtherIssueDate}");
                    doc.InsertParagraph($"Expiry Date: {userData.OtherIssueExpiryDate}");
                }
                doc.InsertParagraph($"Another passport to enter Vietnam: {(userData.BeenToVietNam == 0 ? "Yes" : "No")}");
                if (userData.BeenToVietNam == 0)
                {
                    doc.InsertParagraph($"Passport No: {userData.PassportBeenToVietNamNo}");
                    doc.InsertParagraph($"FullName: {userData.BeenToVietNamFullName}");
                    doc.InsertParagraph($"Issue Date: {userData.BeenToVietNamDateOfBirth}");
                    doc.InsertParagraph($"Nationality: {userData.BeenToVietNamNationality}");
                }
                doc.InsertParagraph($"Multiple or dual nationalities: {(userData.MultipleNationality == 0 ? "Yes" : "No")}");
                if (userData.MultipleNationality == 0)
                {
                    doc.InsertParagraph($"Nationalities: {userData.EnterOtherNationality}");
                }
                doc.InsertParagraph($"Been visited to Viet Nam in the last 01 year period: {(userData.VisitedVietNam == 0 ? "Yes" : "No")}");
                if (userData.VisitedVietNam == 0)
                {
                    doc.InsertParagraph($"From: {userData.VisitedVietNamFrom}");
                    doc.InsertParagraph($"To: {userData.VisitedVietNamTo}");
                    doc.InsertParagraph($"Purpose: {userData.VisitedVietNamPurpose}");
                }
                doc.InsertParagraph($"Intended length of stay in Viet Nam (number of days): {userData.LengthOfStay}");
                doc.InsertParagraph($"Purpose of visit: {userData.PurposeOfVisit}");
                doc.InsertParagraph($"Intended temporary residential address in Viet Nam: {userData.IntendedAddress}");

                doc.InsertParagraph("Requested information").FontSize(18).Bold().Alignment = Alignment.center;
                doc.InsertParagraph($"Grant Evisa valid from: {userData.GrantEvisa}");
                doc.InsertParagraph($"To: {userData.GrantEvisaTo}");
                doc.InsertParagraph($"Allowed to entry through checkpoint: {userData.EntryGate}");
                doc.InsertParagraph($"Exit through checkpoint: {userData.ExitGate}");
                doc.InsertParagraph($"Intended expenses (in USD): {userData.IntendedExpenses}");
                doc.InsertParagraph($"All Trip expenses are borne by: {userData.ExpensesBy}");
                doc.InsertParagraph($"Health insurance arranged for your trip in Viet Nam: {userData.HealthInsurance}");

                foreach (var paragraph in doc.Paragraphs)
                {
                    paragraph.Font(defaultFont);
                    paragraph.SpacingAfter(defaultSpacingAfter);
                }
                doc.Save();
            }

            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "Form.docx");
        }

        public class ConvertImageBase
        {
            public static async Task<string> ImageToBase64(IFormFile image)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    return Convert.ToBase64String(fileBytes);
                }
            }
        }
    }
}
