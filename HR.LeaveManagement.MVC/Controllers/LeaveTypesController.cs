using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _leaveTypeService.GetLeaveTypesAsync();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var ViewModel = new CreateLeaveTypeVM();

            return View(ViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLeaveTypeVM createLeaveTypeVM)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveTypeAsync(createLeaveTypeVM);
                if (response.Success)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(createLeaveTypeVM);
        }


        public async Task<IActionResult> Edit(int Id)
        {
            UpdateLeaveTypeVM model = new UpdateLeaveTypeVM();
            try
            {
                var leaveTypeVM = await _leaveTypeService.GetLeaveTypeDetailsAsync(Id);
                model.DefaultDays = leaveTypeVM.DefaultDays;
                model.Name = leaveTypeVM.Name;

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int Id, LeaveTypeVM model)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveTypeAsync(Id, model);
                if(response.Success)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            var returlModel = new UpdateLeaveTypeVM
            {
                DefaultDays = model.DefaultDays,
                Name = model.Name
            };
            return View(returlModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLeaveTypeAsync(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }


        [HttpGet]
        public async Task<ActionResult> Details(int Id)
        {
            LeaveTypeVM modelVM = default;
            try
            {
                modelVM = await _leaveTypeService.GetLeaveTypeDetailsAsync(Id);
                if (modelVM == null)
                    return RedirectToAction(nameof(Index));


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(modelVM);
        }


    }
}
