using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TheStoneClinic.Models;

namespace TheStoneClinic.Controllers
{
    public class AdminController : Controller
    {
       
            private readonly StoneClinicContext _db;

            public AdminController(StoneClinicContext db)
            {
                _db = db;


            }
            public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Userpage User)
        {
            using (var client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(User), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7244/api/Login", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    var userobj = JsonConvert.DeserializeObject<Userpage>(apiresponse);
                }
            }
            return RedirectToAction("Admin");
        }

        public IActionResult Admin()
        {
            return View();
        }
        public ActionResult Patients()
        {
            return View(_db.PatientDetails.ToList());
        }
        public ActionResult Doctor()
        {
            return View(_db.DoctorDetails.ToList());
        }
        public IActionResult Details(int Id)
        {
            DoctorDetail det = _db.DoctorDetails.Find(Id);

            return View(det);
        }
        public IActionResult Edit(int id)
        {
            DoctorDetail doctor = _db.DoctorDetails.Find(id);
            return View(doctor);

        }
        [HttpPost]
        public IActionResult Edit(DoctorDetail doctor)
        {
            _db.DoctorDetails.Update(doctor);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }
        public IActionResult Create()
        {
            //DoctorDetail doctor = _db.DoctorDetails.Find(id);
            return View();

        }
        [HttpPost]
        public IActionResult Create(DoctorDetail doctor)
        {
            _db.DoctorDetails.Add(doctor);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            DoctorDetail doc = _db.DoctorDetails.Find(id);
            return View(doc);

        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            DoctorDetail doctorDetail = _db.DoctorDetails.Find(id);
            _db.DoctorDetails.Remove(doctorDetail);
            _db.SaveChanges();
            return RedirectToAction("Doctor");
        }
        public IActionResult Cancel(int id)
        {
            AppointmentDetail doc = _db.AppointmentDetails.Find(id);
            return View(doc);

        }
        [HttpPost]
        [ActionName("Cancel")]
        public IActionResult CancelConfirmed(int id)
        {
            AppointmentDetail appointment = _db.AppointmentDetails.Find(id);
            _db.AppointmentDetails.Remove(appointment);
            _db.SaveChanges();
            return RedirectToAction("AppointmentDetails");
        }
        [HttpGet]
        public IActionResult Book()
        {
            ViewBag.DoctorDetails = _db.DoctorDetails.ToList();
            ViewBag.PatientDetails = _db.PatientDetails.ToList();
            return View();
        }
        [HttpPost]
        [ActionName("Book")]
        public IActionResult Booking(AppointmentDetail book)
        {
            _db.AppointmentDetails.Add(book);
            _db.SaveChanges();
            return RedirectToAction("AppointmentDetails");
        }

        public IActionResult AppointmentDetails()
        {
            return View(_db.AppointmentDetails.ToList());

        }
        public IActionResult EditAppointment(int id)
        {
            AppointmentDetail pat = _db.AppointmentDetails.Find(id);
            return View(pat);

        }
        [HttpPost]
        public IActionResult EditAppointment(AppointmentDetail Appoint
            )
        {
            _db.AppointmentDetails.Update(Appoint);
            _db.SaveChanges();
            return RedirectToAction("PatientDetail");
        }

        public IActionResult AddPatient(AppointmentDetail book)
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(PatientDetail patient)
        {
            _db.PatientDetails.Add(patient);
            _db.SaveChanges();
            return RedirectToAction("Patients");
        }
        public IActionResult PatientDetails(int Id)
        {
            PatientDetail patient = _db.PatientDetails.Find(Id);

            return View(patient);
        }
        public IActionResult EditPatient(int id)
        {
            PatientDetail pat = _db.PatientDetails.Find(id);
            return View(pat);

        }
        [HttpPost]
        public IActionResult EditPatient(PatientDetail pat)
        {
            _db.PatientDetails.Update(pat);
            _db.SaveChanges();
            return RedirectToAction("PatientDetail");
        }
        [HttpGet]
        public IActionResult DeletePatient(int id)
        {
            PatientDetail patient = _db.PatientDetails.Find(id);
            return View(patient);

        }
        [HttpPost]
        [ActionName("DeletePatient")]

        public IActionResult DeleteConfirmedPatient(int id)
        {
            PatientDetail patDetail = _db.PatientDetails.Find(id);
            _db.PatientDetails.Remove(patDetail);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }












    }
}
