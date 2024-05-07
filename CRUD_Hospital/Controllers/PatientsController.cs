using Microsoft.AspNetCore.Mvc;
using CRUD_Hospital.Data;
using CRUD_Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Hospital.Controllers
{
    public class PatientsController : Controller
    {
        private readonly MVCDemoDBContext _mVCDemoDBContext;
        public PatientsController(MVCDemoDBContext mVCDemoDBContext)
        {
            this._mVCDemoDBContext = mVCDemoDBContext;
        }
        [HttpGet]

        public async Task<IActionResult>Index()
        {
            var patients = await _mVCDemoDBContext.Patients.ToListAsync();
            return View(patients);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Add(AddPatientViewModel addPatientrequest)
        {
            var patient = new Patient()
            {
                Id = Guid.NewGuid(),
                Name = addPatientrequest.PatientName,
                Address = addPatientrequest.Address,
                Mobile = addPatientrequest.Mobile,
                RegistrationDate = addPatientrequest.RegistrationDate
            };
            await _mVCDemoDBContext.Patients.AddAsync(patient);
            await _mVCDemoDBContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult>View(Guid Id)
        {
            var patientData = await _mVCDemoDBContext.Patients.FirstOrDefaultAsync(a=>a.Id == Id);
            if(patientData != null)
            {
                var viewModel = new UpdatePatientViewModel()
                {
                    Id = patientData.Id,
                    PatientName = patientData.Name,
                    Address = patientData.Address,
                    Mobile = patientData.Mobile,
                    RegistrationDate = patientData.RegistrationDate
                };
                return await Task.Run(()=> View("View",viewModel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult>View(UpdatePatientViewModel updatePatientViewModel)
        {
            if(ModelState.IsValid)
            {
                var patientData = await _mVCDemoDBContext.Patients.FindAsync(updatePatientViewModel.Id);
                if(patientData != null)
                {
                    patientData.Name  = updatePatientViewModel.PatientName;
                    patientData.Address = updatePatientViewModel.Address;
                    patientData.Mobile = updatePatientViewModel.Mobile;
                    patientData.RegistrationDate = updatePatientViewModel.RegistrationDate;
                    await _mVCDemoDBContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdatePatientViewModel deletePatientViewModel)
        {
            var patientData = await _mVCDemoDBContext.Patients.FindAsync(deletePatientViewModel.Id);
            if(patientData != null)
            {
                _mVCDemoDBContext.Patients.Remove(patientData);
                await _mVCDemoDBContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
