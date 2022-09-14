using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Abstract;
using ViewModels;

namespace FormValidationDDD.Controllers
{
    public class PlayerController : Controller
    {
        IPlayerRepository _repository;
        public PlayerController(IPlayerRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.AllItems.Select(s => new PlayerVM(s)));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            try
            {
                _repository.AddItemAsync(new Player
                {
                    Name = player.Name,
                    Email = player.Email,
                    Country = player.Country,
                    Sex = player.Sex,
                    BirthDate = player.BirthDate,
                    HeroType = player.HeroType,
                    Experience = player.Experience
                });

                return Redirect("~/Player");
            }
            catch
            {
                return Redirect("~/Player");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id.HasValue)
            {
                Player? player = await _repository.GetItemAsync(id.Value);
                if (player != null)
                {
                    return View(player);
                }
            }
            return Redirect("~/Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Player player)
        {
            await _repository.GhangeItemAsync(player);
            return Redirect("~/Player");
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id.HasValue)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                Player? player = await _repository.GetItemAsync(id.Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                if (player != null)
                    return View(player);
            }

            return Redirect("~/Error");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id.HasValue)
            {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                Player? player = await _repository.GetItemAsync(id.Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                if (player != null)
                    return View(player);
            }

            return Redirect("~/Error");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Player player)
        {
            if (player != null)
            {
                await _repository.DeleteItemAsync(player.Id);
            }
            return Redirect("~/Player");
        }
    }
}
