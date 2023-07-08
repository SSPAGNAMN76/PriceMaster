using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceMaster.Models;
using PriceMaster.Services;

namespace PriceMaster.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _authenticationService.Authenticate(model.UserName, model.Password);

                if (user != null)
                {
                    // Autenticazione riuscita
                    // Esegui le azioni necessarie, ad esempio impostare il cookie di autenticazione
                    return RedirectToAction("Index", "Home");
                }

                // Autenticazione fallita
                ModelState.AddModelError("", "Credenziali di accesso non valide");
            }

            // Mostra la vista di login con gli eventuali messaggi di errore
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Effettua la registrazione dell'utente utilizzando i dati del modello
                // Esegui le azioni necessarie, ad esempio salvare l'utente nel database
                // e impostare il cookie di autenticazione
                // Redirect all'azione successiva o alla pagina di benvenuto

                return RedirectToAction("Index", "Home");
            }

            // Mostra la vista di registrazione con gli eventuali messaggi di errore
            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            var model = new ForgotPasswordModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                // Effettua il recupero della password utilizzando i dati del modello
                // Esegui le azioni necessarie, ad esempio inviare un'email con il link di reset della password
                // Redirect all'azione successiva o a una pagina di conferma

                return RedirectToAction("PasswordResetConfirmation");
            }

            // Mostra la vista di recupero password con gli eventuali messaggi di errore
            return View(model);
        }

        public IActionResult PasswordResetConfirmation()
        {
            return View();
        }

        [Authorize(Roles = "Administrators")]
        public IActionResult AdminOnlyAction()
        {
            // Esegui l'azione consentita solo agli amministratori
            return View();
        }
    }


}
