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
    public class VendasController : ApiController
    {
        private VendasBackContext db = new VendasBackContext();
        static HttpClient client = new HttpClient();

        // GET: api/Vendas
        public IQueryable<Venda> GetVendas()
        {
            return db.Vendas;
        }

        // GET: api/Vendas/5
        [ResponseType(typeof(Venda))]
        public async Task<IHttpActionResult> GetVenda(int id)
        {
            Venda venda = await db.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        // PUT: api/Vendas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVenda(int id, Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venda.idVenda)
            {
                return BadRequest();
            }

            db.Entry(venda).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
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

        // POST: api/Vendas
        [ResponseType(typeof(Venda))]
        public async Task<IHttpActionResult> PostVenda(Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendas.Add(venda);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = venda.idVenda }, venda);
        }

        // DELETE: api/Vendas/5
        [ResponseType(typeof(Venda))]
        public async Task<IHttpActionResult> DeleteVenda(int id)
        {
            Venda venda = await db.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            db.Vendas.Remove(venda);
            await db.SaveChangesAsync();

            return Ok(venda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendaExists(int id)
        {
            return db.Vendas.Count(e => e.idVenda == id) > 0;
        }


        [Route("Faturamento/{mes}")]
        [ResponseType(typeof(List<Venda>))]
        public async Task<IHttpActionResult> GetFaturamentoMesAsync(int mes)
        {
            var vendasClass = db.Vendas.Where(c => c.data.Month == mes).ToList();
            if (vendasClass == null)
            {
                return BadRequest();
            }

            double totalVendas = 0;
            double constant = 1.3;
            double preco = await GetPrecoAsync();

            foreach (var vendas in vendasClass)
            {
                totalVendas += vendas.quantidade * (preco * constant);
            }

            return Ok(Math.Round(totalVendas, 2));
        }

        [Route("Faturamento/")]
        [ResponseType(typeof(List<Venda>))]
        public async Task<IHttpActionResult> GetFaturamentoAsync()
        {
            DateTime currentyTime = DateTime.UtcNow.Date;
            var vendasClass = db.Vendas.Where(c => c.data.Year==currentyTime.Year).ToList();

            if (vendasClass == null)
            {
                return BadRequest();
            }

            double totalVendas = 0;
            double constant = 1.3;
            double preco = await GetPrecoAsync();

            foreach (var vendas in vendasClass)
            {
                totalVendas += vendas.quantidade * (preco * constant);
            }

            return Ok(Math.Round(totalVendas, 2));
        }

        static async Task<double> GetPrecoAsync()
        {
            Object valores = null;

            HttpResponseMessage response = await client.GetAsync(@"http://trabalhosige.azurewebsites.net/api/CustoMateriaPrima");
            if (response.IsSuccessStatusCode)
            {
                valores = await response.Content.ReadAsAsync<Object>();
            }
            return Convert.ToDouble(valores);
        }
    }
}