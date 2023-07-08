using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceMaster.Services;
using PriceMaster.ViewModels;

namespace PriceMaster.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConfigurationParameterController : Controller
    {
        private readonly IConfigurationParameterService _parameterService;

        public ConfigurationParameterController(IConfigurationParameterService parameterService)
        {
            _parameterService = parameterService;
        }


        [Route("administrator/configurationparameter")]
        public IActionResult Index()
        {
            var currentConfiguration = _parameterService.GetCurrentConfiguration();
            var errorlist = new List<string>();
            
            if (currentConfiguration.IsValid(out errorlist))
            {
                return Edit(currentConfiguration.Id);
            }

            return Create();
        }


        public IActionResult Create()
        {
            return View(new ConfigurationParameterViewModel());
        }

        [HttpPost]
        public IActionResult Create(ConfigurationParameterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var parameter = viewModel.ToConfigurationParameter();
                _parameterService.AddParameter(parameter);

                return RedirectToAction("Index", "Home"); // Redirigi all'azione "Index" del controller "Home" dopo l'inserimento
            }

            return View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var parameter = _parameterService.GetParameterById(id);

            if (parameter == null)
            {
                return NotFound();
            }

            var viewModel = ConfigurationParameterViewModel.FromConfigurationParameter(parameter);
            viewModel.IsEditing = true;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ConfigurationParameterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var parameter = viewModel.ToConfigurationParameter();
                _parameterService.UpdateParameter(parameter);

                return RedirectToAction("Index", "Home"); // Redirigi all'azione "Index" del controller "Home" dopo la modifica
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _parameterService.DeleteParameter(id);

            return RedirectToAction("Index", "Home"); // Redirigi all'azione "Index" del controller "Home" dopo la cancellazione
        }
    }
}
