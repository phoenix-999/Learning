using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiControllers.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IRepository repository;
        public ReservationsController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservations;

        [HttpGet("{id}")]
        public Reservation Get(int id) => repository[id];

        [HttpPost]
        public Reservation Post([FromBody]Reservation reservation)
        {
            return repository.AddOrUpdateReservation(reservation);
        }

        [HttpPut]
        public Reservation Put([FromBody]Reservation reservation)
        {
            return repository.AddOrUpdateReservation(reservation);
        }

        [HttpPatch("{id}")]
        public Reservation Patch(int id, JsonPatchDocument<Reservation> patch) //При отправке запроса надо заполнить все доступные поля обьекта
        {
            var reservation = repository[id];
            if (reservation == null)
                return null;
            patch.ApplyTo(reservation);
            return reservation;
        }

        [HttpDelete]
        public void Delete([FromBody]Reservation reservation)
        {
            repository.RemoveReservation(reservation);
        }
    }
}