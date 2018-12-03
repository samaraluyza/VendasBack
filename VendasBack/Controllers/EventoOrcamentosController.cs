using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VendasBack.Models;

namespace VendasBack.Controllers
{
    public class EventoOrcamentosController : ApiController
    {
        private VendasBackContext db = new VendasBackContext();

        // GET: api/EventoOrcamentos
        public IQueryable<EventoOrcamento> GetEventoOrcamentoes()
        {
            return db.EventoOrcamentoes;
        }

        // GET: api/EventoOrcamentos/5
        [ResponseType(typeof(EventoOrcamento))]
        public async Task<IHttpActionResult> GetEventoOrcamento(int id)
        {
            EventoOrcamento eventoOrcamento = await db.EventoOrcamentoes.FindAsync(id);
            if (eventoOrcamento == null)
            {
                return NotFound();
            }

            return Ok(eventoOrcamento);
        }

        // PUT: api/EventoOrcamentos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventoOrcamento(int id, EventoOrcamento eventoOrcamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventoOrcamento.IdEventoOrcamento)
            {
                return BadRequest();
            }

            db.Entry(eventoOrcamento).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoOrcamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EventoOrcamentos
        [ResponseType(typeof(EventoOrcamento))]
        public async Task<IHttpActionResult> PostEventoOrcamento(EventoOrcamento eventoOrcamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventoOrcamentoes.Add(eventoOrcamento);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventoOrcamento.IdEventoOrcamento }, eventoOrcamento);
        }

        // DELETE: api/EventoOrcamentos/5
        [ResponseType(typeof(EventoOrcamento))]
        public async Task<IHttpActionResult> DeleteEventoOrcamento(int id)
        {
            EventoOrcamento eventoOrcamento = await db.EventoOrcamentoes.FindAsync(id);
            if (eventoOrcamento == null)
            {
                return NotFound();
            }

            db.EventoOrcamentoes.Remove(eventoOrcamento);
            await db.SaveChangesAsync();

            return Ok(eventoOrcamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventoOrcamentoExists(int id)
        {
            return db.EventoOrcamentoes.Count(e => e.IdEventoOrcamento == id) > 0;
        }
    }
}