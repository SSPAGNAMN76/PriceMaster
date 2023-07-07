using Microsoft.AspNetCore.Mvc;
using PriceMaster.Services;
using PriceMaster.Views.Administrator;

namespace PriceMaster.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IConfigurationParameterService _configurationParameterService;

        public AdministratorController(IConfigurationParameterService configurationParameterService)
        {
            _configurationParameterService = configurationParameterService;
        }

        [HttpGet]
        public IActionResult ConfigurationParameters()
        {
            var configurationParameter = _configurationParameterService.GetParameterById(1); // Esempio: recupera il ConfigurationParameter con Id 1
            var viewModel = new ConfigurationParametersViewModel()
            {
                ConfigurationParameter = configurationParameter
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfigurationParameters(ConfigurationParametersViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (!viewModel.ConfigurationParameter.IsValid(out List<string> validationErrors))
            {
                viewModel.ValidationErrors = validationErrors;
                return View(viewModel);
            }

            _configurationParameterService.UpdateParameter(viewModel.ConfigurationParameter);
            viewModel.ContentSaved = true;

            return View(viewModel);
        }
    }
}

